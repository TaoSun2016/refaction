using System.Data.Entity;
using System.Linq;
namespace refactor_me.Models
{
    public class ProductRepository : BaseRepository<Product>, IRepository<Product>
    {
        public ProductRepository()
        {
            Table = dbContext.Products;
        }
        public new int Delete(Product entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            foreach (var option in dbContext.ProductOptions.Where(m => m.ProductId == entity.Id))
            {
                dbContext.ProductOptions.Remove(option);
            }
            return SaveChanges();
        }
        public IQueryable<Product> GetByName(string name)
        {
            return Table.Where(m => m.Name.Contains(name));
        }
    }
}