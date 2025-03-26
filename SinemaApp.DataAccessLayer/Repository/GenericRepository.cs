using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinemaApp.DataAccessLayer.Abstract;
using SinemaApp.DataAccessLayer.Context;

namespace SinemaApp.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly SinemaAppContext _context;
        

        public GenericRepository(SinemaAppContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var item = await _context.Set<T>().FindAsync(entity);
            if (item != null)
            {
                typeof(T).GetProperty("IsDeleted")?.SetValue(item, true);
                await _context.SaveChangesAsync();
            }

          }

        public async Task<List<T>> FilterAsync(Expression<Func<T, bool>> predicate)
        {
            /*İlgili tablodan verileri çeker ve gerekli filtreleri uygular*/
            return await _context.Set<T>()
            //.Where(x => !EF.Property<bool>(x, "IsDeleted")) 
            .Where(predicate)
            .ToListAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
