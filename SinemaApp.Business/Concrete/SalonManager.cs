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
    public class SalonManager : ISalonManager
    {
        private readonly IGenericDal<Salon> _salonDal;
        public SalonManager(IGenericDal<Salon> salonDal)
        {
            _salonDal = salonDal;
        }

        public Task<Salon> GetFilterAsync(Expression<Func<Salon, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task TAddAsync(Salon entity)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(Salon entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Salon>> TFilterAsync(Expression<Func<Salon, bool>> filter)
        {
            return await _salonDal.GetQueryable()
            .Include(s => s.Seanslar)  
            .ToListAsync();
        }
         
        public Task TUpdateAsync(Salon entity)
        {
            throw new NotImplementedException();
        }
    }
}
