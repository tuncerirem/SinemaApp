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
    public class KoltukManager : IKoltukManager
    {
        public Task<List<Koltuk>> GetAllWithSeansAsync()
        {
            throw new NotImplementedException();
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

        public Task<List<Koltuk>> TFilterAsync(Expression<Func<Koltuk, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(Koltuk entity)
        {
            throw new NotImplementedException();
        }
    }
}
