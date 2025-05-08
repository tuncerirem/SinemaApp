using Microsoft.EntityFrameworkCore;
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
    public class KoltukManager : IKoltukManager
    {
        private readonly IGenericDal<Koltuk> _koltukDal;
        public KoltukManager(IGenericDal<Koltuk>  koltukDal)
        {
            _koltukDal = koltukDal;
        }
        public Task<Koltuk> GetFilterAsync(Expression<Func<Koltuk, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task TAddAsync(Koltuk entity)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(Koltuk entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Koltuk>> TFilterAsync(Expression<Func<Koltuk, bool>> filter)
        {
            return await _koltukDal.GetQueryable()
                                   .Where(filter)
                                   .ToListAsync();
        }

        public async Task TUpdateAsync(Koltuk entity)
        {
            await _koltukDal.UpdateAsync(entity);
        }
    }
}
