using System;
using System.Linq;
using System.Data.Entity;

namespace refactor_me.Models
{
    public abstract class BaseRepository<T> : IDisposable where T:class,new()
    {
        public ProductDB dbContext { get; } = new ProductDB();

        public DbSet<T> Table;

        public IQueryable<T> GetAll() => Table;
        public T GetOne(Guid id) => Table.Find(id);
        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }
        public int Update(Guid id, T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        public int Delete(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();        
        }
        internal int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch 
            {
                //exception handled
                throw;
            }
        }
        bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                dbContext.Dispose();
            }

           _disposed = true;
        }
    }
}