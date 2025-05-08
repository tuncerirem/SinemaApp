using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaApp.API.DTO;
using SinemaApp.Business.Abstract;

namespace SinemaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoltukController : ControllerBase
    {
        private readonly IKoltukManager _koltukManager;
        public KoltukController(IKoltukManager koltukManager)
        {
            _koltukManager = koltukManager;
        }


        [HttpGet("GetAllKoltuks")]

        public async Task<ActionResult<List<Koltuk_DTO>>> GetAllKoltuks()
        {
            var koltuklar = await _koltukManager.TFilterAsync(k => true);
            var koltukDtos = koltuklar.Select(k => new Koltuk_DTO
            {
                Id = k.Id,
                Durum = k.Durum,
            });
            return Ok(koltukDtos);
        }

        
        [HttpPost("SatinAl")]
        public async Task<IActionResult> SatinAl([FromBody] List<int> secilenKoltukIds)
        {
            if (secilenKoltukIds == null || !secilenKoltukIds.Any())
                return BadRequest(new { message = "Hiç koltuk seçilmedi." });

            var koltuklar = await _koltukManager.TFilterAsync(k => secilenKoltukIds.Contains(k.Id));

            if (koltuklar == null || !koltuklar.Any())
                return NotFound(new { message = "Seçilen koltuklar bulunamadı." });

            var doluKoltuklar = koltuklar.Where(k => k.Durum == "Dolu").ToList();

            if (doluKoltuklar.Any())
            {
                return BadRequest(new { message = "Seçtiğiniz koltuklardan bazıları zaten dolu." });
            }
            foreach (var koltuk in koltuklar)
            {
                koltuk.Durum = "Dolu";
                await _koltukManager.TUpdateAsync(koltuk);
            }

            return Ok(new { message = "Koltuklar başarıyla satın alındı." });
        }

    }
}

