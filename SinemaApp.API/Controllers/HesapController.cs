using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaApp.DataAccessLayer.Context;
using SinemaApp.API.DTO;
using SinemaApp.Business.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SinemaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HesapController : ControllerBase
    {
        private readonly IKullaniciManager _kullaniciManager;

        public HesapController(IKullaniciManager kullaniciManager)
        {
            _kullaniciManager = kullaniciManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login_DTO dto)
        {

            var kullanici = await _kullaniciManager.GetFilterAsync(x => x.Email == dto.Email && x.Sifre == dto.Sifre);
            

            if (kullanici == null)
            {
                return Unauthorized("Geçersiz email veya şifre");
            }

            return Ok(new { redirectURL = "/Home/Filmler" });
        }

    }
}
