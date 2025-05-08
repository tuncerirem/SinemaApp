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
    public class BiletManager : IBiletManager
    {
        private readonly IGenericDal<Bilet> _biletDal;
        public BiletManager(IGenericDal<Bilet> biletDal)
        {
            _biletDal = biletDal;
        }

        public Task<List<Bilet>> GetAllWithSeansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Bilet> GetFilterAsync(Expression<Func<Bilet, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Salon> GetSalonWithSeansAsync(Expression<Func<Salon, bool>> filter)
        {
            throw new NotImplementedException();
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
