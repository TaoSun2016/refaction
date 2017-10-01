namespace refactor_me.Models
{
    public class ProductOptionRepository : BaseRepository<ProductOption>, IRepository<ProductOption>
    {
        public ProductOptionRepository()
        {
            Table = dbContext.ProductOptions;
        }
    }
}