using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaApp.API.DTO;
using SinemaApp.Business.Abstract;
using SinemaApp.Entities.Concrete;
using System.Security.Claims;

namespace SinemaApp.API.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IFilmManager _filmManager;
        private readonly ISeansManager _seansManager;

        public AdminController(IFilmManager filmManager, ISeansManager seansManager)
        {
            _filmManager = filmManager;
            _seansManager = seansManager;
        }
        [HttpPost("FilmEkle")]
        
        public async Task<IActionResult> FilmEkle([FromBody] Film_DTO dto)
        {

            //var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            //if (userRole != "Admin")
            //{
            //    return Forbid();
            //}


            var film = new Film
            {
                Ad = dto.Ad,
                Tur = dto.Tur,
                Zaman = dto.Zaman,
                Fotograf = dto.Fotograf,
                Fragman = dto.Fragman
            };

            await _filmManager.TAddAsync(film);

            
            var seansEntities = dto.Seanslar.Select(seans => new Seans
            {
                Baslangic = seans.Baslangic,
                Bitis = seans.Bitis,
                FilmId = film.Id
            });

            foreach (var seans in seansEntities)
            {
                await _seansManager.TAddAsync(seans);
            }

            return Ok("Film ve seanslar başarıyla eklendi.");
        }
    }
}
