using SinemaApp.Business.Abstract;
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
        public Task<List<Salon>> GetAllWithSeansAsync()
        {
            throw new NotImplementedException();
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

        public Task<List<Salon>> TFilterAsync(Expression<Func<Salon, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(Salon entity)
        {
            throw new NotImplementedException();
        }
    }
}
