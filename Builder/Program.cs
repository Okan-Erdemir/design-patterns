using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountPrice);
            Console.ReadLine();
        }
    }
    //Birbiri arkasına gelicek işlemlere göre oluşturma eylemi diyebiliriz.
    class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductModel GetModel();

    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductModel model = new ProductModel();

        public override void ApplyDiscount()
        {
            model.DiscountPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductModel model = new ProductModel();
        public override void ApplyDiscount()
        {
            model.DiscountPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override ProductModel GetModel()
        {
            return model;
        }

    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
