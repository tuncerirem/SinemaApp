using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaApp.Business.Abstract;
using SinemaApp.Business.Concrete;
using SinemaApp.DataAccessLayer.Context;
using SinemaApp.Entities.Concrete;

namespace SinemaApp.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private IKullaniciManager _kullaniciManager;

        public KullaniciController(IKullaniciManager kullaniciManager)
        {
            _kullaniciManager = kullaniciManager;
        }

        [HttpGet]
        public async Task<List<Kullanici>> Get() 
        {
            var kullanicilar = await _kullaniciManager.TFilterAsync(x=>true);

            return (kullanicilar);
        }

 
    }
}
