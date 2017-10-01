namespace refactor_me.Models
{
    using System.Data.Entity;

    public partial class ProductDB : DbContext
    {
        public ProductDB()
            : base("name=ProductDB")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
