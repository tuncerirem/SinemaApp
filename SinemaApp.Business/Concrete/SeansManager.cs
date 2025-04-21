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
    public class SeansManager : ISeansManager
    {
        public Task<List<Seans>> GetAllWithSeansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Seans> GetFilterAsync(Expression<Func<Seans, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task TAddAsync(Seans entity)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(Seans entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seans>> TFilterAsync(Expression<Func<Seans, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(Seans entity)
        {
            throw new NotImplementedException();
        }
    }
}
