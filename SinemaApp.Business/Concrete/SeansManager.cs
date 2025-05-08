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
    public class SeansManager : ISeansManager
    {
        private readonly IGenericDal<Seans> _seansDal;
        public SeansManager(IGenericDal<Seans> seansDal)
        {
            _seansDal = seansDal;
        }
        

        public Task<Seans> GetFilterAsync(Expression<Func<Seans, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task TAddAsync(Seans entity)
        {
            await _seansDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Seans entity)
        {
            await _seansDal.DeleteAsync(entity); ;
        }

        public Task<List<Seans>> TFilterAsync(Expression<Func<Seans, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task TUpdateAsync(Seans entity)
        {
            await _seansDal.UpdateAsync(entity); 
        }
    }
}
