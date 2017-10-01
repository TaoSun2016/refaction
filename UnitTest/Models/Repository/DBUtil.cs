using refactor_me.Models;
using System;

namespace UnitTest.Models.Repository
{
    public static class DBUtil
    {
        public static void InitDB()
        {
            ProductDB db = new ProductDB();
            foreach (var i in db.Products)
            {
                db.Products.Remove(i);
            }
            foreach (var i in db.ProductOptions)
            {
                db.ProductOptions.Remove(i);
            }

            Guid SamsungGuid = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3");
            Guid AppleGuid = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3");
            Guid HuaWeiGuid = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafe88");

            db.Products.Add(new Product { Id = SamsungGuid, Name = "Samsung Galaxy S7", Description = "Newest mobile product from Samsung.", Price = 1024.99m, DeliveryPrice = 16.99m });
            db.Products.Add(new Product { Id = AppleGuid, Name = "Apple iPhone 6S", Description = "Newest mobile product from Apple.", Price = 1299.99m, DeliveryPrice = 15.99m });
            db.Products.Add(new Product { Id = HuaWeiGuid, Name = "HuaWei Honor 9", Description = "Newest mobile product from HuaWei.", Price = 1999.99m, DeliveryPrice = 18.00m });

            db.ProductOptions.Add(new ProductOption { Id = new Guid("0643ccf0-ab00-4862-b3c5-40e2731abcc9"), ProductId = SamsungGuid, Name = "White", Description = "White Samsung Galaxy S7" });
            db.ProductOptions.Add(new ProductOption { Id = new Guid("a21d5777-a655-4020-b431-624bb331e9a2"), ProductId = SamsungGuid, Name = "Balck", Description = "Black Samsung Galaxy S7" });
            db.ProductOptions.Add(new ProductOption { Id = new Guid("5c2996ab-54ad-4999-92d2-89245682d534"), ProductId = AppleGuid, Name = "Rose Gold", Description = "Gold Apple iPhone 6S" });
            db.ProductOptions.Add(new ProductOption { Id = new Guid("9ae6f477-a010-4ec9-b6a8-92a85d6c5f03"), ProductId = AppleGuid, Name = "White", Description = "White Apple iPhone 6S" });
            db.ProductOptions.Add(new ProductOption { Id = new Guid("4e2bc5f2-699a-4c42-802e-ce4b4d2ac0ef"), ProductId = AppleGuid, Name = "Balck", Description = "Black Apple iPhone 6S" });
            db.ProductOptions.Add(new ProductOption { Id = new Guid("4e2bc5f2-699a-4c42-802e-ce4b4d2ac088"), ProductId = HuaWeiGuid, Name = "Gold", Description = "Gold HuaWei Honor 9" });
            db.SaveChanges();
        }
    }
}
