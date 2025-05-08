using SinemaApp.Business.Abstract;
using SinemaApp.DataAccessLayer.Abstract;
using SinemaApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Business.Concrete
{
    public class KullaniciManager : IKullaniciManager
    {
        private readonly IGenericDal<Kullanici> _kullaniciDal;

        public KullaniciManager(IGenericDal<Kullanici> kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }


        public async Task<Kullanici> GetFilterAsync(Expression<Func<Kullanici, bool>> filter)
        {
            return await _kullaniciDal.GetFilterAsync(filter);
        }

        public async Task TAddAsync(Kullanici entity)
        {
            await _kullaniciDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Kullanici entity)
        {
            await _kullaniciDal.DeleteAsync(entity);
        }

        public async Task<List<Kullanici>> TFilterAsync(Expression<Func<Kullanici, bool>> filter)
        {
            return await _kullaniciDal.FilterAsync(filter);
        }
        public async Task TUpdateAsync(Kullanici entity)
        {
            await _kullaniciDal.UpdateAsync(entity);
        }
    }
}
