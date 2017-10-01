using System;

namespace refactor_me.Models
{
    public class ProductDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<ProductDB>
    {
        protected override void Seed(ProductDB context)
        {
            Guid SamsungGuid = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3");
            Guid AppleGuid = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3");
            context.Products.Add(new Product {Id = SamsungGuid, Name= "Samsung Galaxy S7", Description= "Newest mobile product from Samsung.", Price=1024.99m, DeliveryPrice=16.99m });
            context.Products.Add(new Product { Id = AppleGuid, Name = "Apple iPhone 6S", Description = "Newest mobile product from Apple.", Price = 1299.99m, DeliveryPrice = 15.99m });

            context.ProductOptions.Add(new ProductOption { Id = new Guid("0643ccf0-ab00-4862-b3c5-40e2731abcc9"), ProductId = SamsungGuid, Name= "White", Description= "White Samsung Galaxy S7" });
            context.ProductOptions.Add(new ProductOption { Id = new Guid("a21d5777-a655-4020-b431-624bb331e9a2"), ProductId = SamsungGuid, Name = "Balck", Description = "Black Samsung Galaxy S7" });
            context.ProductOptions.Add(new ProductOption { Id = new Guid("5c2996ab-54ad-4999-92d2-89245682d534"), ProductId = AppleGuid, Name = "Rose Gold", Description = "Gold Apple iPhone 6S" });
            context.ProductOptions.Add(new ProductOption { Id = new Guid("9ae6f477-a010-4ec9-b6a8-92a85d6c5f03"), ProductId = AppleGuid, Name = "White", Description = "White Apple iPhone 6S" });
            context.ProductOptions.Add(new ProductOption { Id = new Guid("4e2bc5f2-699a-4c42-802e-ce4b4d2ac0ef"), ProductId = AppleGuid, Name = "Balck", Description = "Black Apple iPhone 6S" });

            base.Seed(context); 
        }
    }
}