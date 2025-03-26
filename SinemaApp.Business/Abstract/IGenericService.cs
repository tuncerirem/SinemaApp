using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> TFilterAsync(Expression<Func<T, bool>> predicate);
        Task TAddAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(T entity);
    }
}
