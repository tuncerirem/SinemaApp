using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaApp.API.DTO;
using SinemaApp.Business.Abstract;

namespace SinemaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController : ControllerBase
    {
        private readonly ISalonManager _salonManager;
        public SalonController(ISalonManager salonManager)
        {
            _salonManager = salonManager;
        }

        [HttpGet("GetAllSalons")]
        public async Task<ActionResult<List<Salon_DTO>>> GetAllSalons()
        {
            var salons = await _salonManager.TFilterAsync(s => true);
            var dtoList = salons.Select(s => new Salon_DTO
            {
                Id = s.Id,
                Ad = s.Ad,
                Seanslar = s.Seanslar.Select(seans => new Seans_DTO
                {
                    Id = seans.Id,
                    Baslangic = seans.Baslangic,
                    Bitis = seans.Bitis,
                }).ToList()

            });

            return Ok(dtoList);
        }
    }
}
