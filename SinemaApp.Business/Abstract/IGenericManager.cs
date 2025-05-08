using SinemaApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Business.Abstract
{
    public interface IGenericManager<T> where T : class
    {
        Task<T> GetFilterAsync(Expression<Func<T, bool>> filter);
        Task TAddAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(T entity);
        Task<List<T>> TFilterAsync(Expression<Func<T, bool>> filter);
    }
}
