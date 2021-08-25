using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrucknDriver.Services
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllByCondition(Expression<Func<T, bool>> expression);
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<T> Upload(T entity);
    }
}
