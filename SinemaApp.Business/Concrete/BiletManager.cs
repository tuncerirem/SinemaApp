using SinemaApp.Business.Abstract;
using SinemaApp.DataAccessLayer.Abstract;
using SinemaApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


//DEPENDENCY INJECTION 


namespace SinemaApp.Business.Concrete
{
    public class BiletManager : IBiletService
    {
        private readonly IBiletDal _biletDal;
        public BiletManager(IBiletDal biletDal)
        {
            _biletDal = biletDal;
        }
        public Task TAddAsync(Bilet entity)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(Bilet entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bilet>> TFilterAsync(Expression<Func<Bilet, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(Bilet entity)
        {
            throw new NotImplementedException();
        }
    }
}
