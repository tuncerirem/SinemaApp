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
    public class RolManager : IRolManager
    {
        public Task<List<Rol>> GetAllWithSeansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Rol> GetFilterAsync(Expression<Func<Rol, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task TAddAsync(Rol entity)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(Rol entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Rol>> TFilterAsync(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(Rol entity)
        {
            throw new NotImplementedException();
        }
    }
}
