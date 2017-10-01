using System;
using System.Linq;

namespace refactor_me.Models
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetOne(Guid id);
        int Add(T entity);
        int Update(Guid id, T entity);
        int Delete(T entity);
    }
}
