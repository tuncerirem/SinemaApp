using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaApp.API.DTO;
using SinemaApp.Business.Abstract;

namespace SinemaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmManager _filmManager;

        public FilmController(IFilmManager filmManager)
        {
            _filmManager = filmManager;
        }


        [HttpGet]
        public async Task<ActionResult<List<Film_DTO>>> GetAllFilms()
        {
            var films = await _filmManager.GetAllWithSeansAsync();
            var filmDtos = films.Select(f => new Film_DTO
            {
                Id = f.Id,
                Ad = f.Ad,
                Tur = f.Tur,
                Zaman = f.Zaman,
                Fotograf = f.Fotograf,
                Fragman = f.Fragman,
                Seanslar = f.Seanslar.Select(s => new Seans_DTO
                {
                    Id = s.Id,
                    Baslangic = s.Baslangic,
                    Bitis = s.Bitis
                }).ToList()
            }).ToList();
            return Ok(filmDtos);
        }
    }

}
