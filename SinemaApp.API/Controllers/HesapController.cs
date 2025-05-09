using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaApp.DataAccessLayer.Context;
using SinemaApp.API.DTO;
using SinemaApp.Business.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using SinemaApp.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using SinemaApp.Business.Concrete;
using SinemaApp.API.Security;

namespace SinemaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HesapController : ControllerBase
    {
        private readonly IKullaniciManager _kullaniciManager;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly TokenGenerator _tokenGenerator;

        public HesapController(IKullaniciManager kullaniciManager, IPasswordHasher passwordHasher, IConfiguration configuration)
        {
            _kullaniciManager = kullaniciManager;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _tokenGenerator = new TokenGenerator(_configuration);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login_DTO dto)
        {
            var kullanici = await _kullaniciManager.GetFilterAsync(x => x.Email == dto.Email);

            if (kullanici == null)
            {
                return BadRequest(new { message = "Geçersiz email veya şifre" });
            }

            var sonuc = _passwordHasher.Verify(dto.Sifre, kullanici.Sifre);
            if (!sonuc)
            {
                return BadRequest(new { message = "Geçersiz email veya şifre" });
            }

            
            string rol = kullanici.RolId == 1 ? "Admin" : "Kullanici";

            var token = _tokenGenerator.GenerateToken(kullanici.Email, rol);

            string redirectUrl = rol == "Admin" ? "/Home/Admin" : "/Home/Filmler";

            return Ok(new
            {
                token = token.AccessToken,
                expires = token.Expiration,
                role = rol,
                redirectURL = redirectUrl
            });
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Kullanici_DTO dto)
        {

            var hashedPassword = _passwordHasher.Hash(dto.Sifre);  

            var yeniKullanici = new Kullanici
            {
                Email = dto.Email,
                Sifre = hashedPassword, 
                Ad = dto.Ad,
                Soyad = dto.Soyad,
                RolId = 2
               
            };

            await _kullaniciManager.TAddAsync(yeniKullanici);

            return Ok(new { message = "Kayıt başarılı! Şimdi giriş yapabilirsiniz." });
        }

    }
}
