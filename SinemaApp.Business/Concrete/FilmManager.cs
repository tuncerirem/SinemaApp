using Microsoft.EntityFrameworkCore;
using SinemaApp.Business.Abstract;
using SinemaApp.DataAccessLayer.Abstract;
using SinemaApp.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Business.Concrete
{

    public class FilmManager : IFilmManager
    {
        private readonly IGenericDal<Film> _filmDal;
        public FilmManager(IGenericDal<Film> filmDal)
        {
            _filmDal = filmDal;
        }

        public Task<Film> GetFilterAsync(Expression<Func<Film, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task TAddAsync(Film entity)
        {
            await _filmDal.AddAsync(entity);

        }

        public async Task TDeleteAsync(Film entity)
        {
            await _filmDal.DeleteAsync(entity);
        }

        public async Task<List<Film>> TFilterAsync(Expression<Func<Film, bool>> filter)
        {
            return await _filmDal.FilterAsync(filter);
        }

        public async Task TUpdateAsync(Film entity)
        {
            await _filmDal.UpdateAsync(entity);
        }
        public async Task<List<Film>> GetAllWithSeansAsync()
        {
            return await _filmDal.GetQueryable()
                                 .Include(f => f.Seanslar)
                                 .ToListAsync();
        }

    }

}
