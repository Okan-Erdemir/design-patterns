using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //bir nesnenin başka bir nesneye bağlanmamasıdır.


            IKernel kernel = new StandardKernel();
            kernel.Bind<IProduct>().To<NhProductDal>().InSingletonScope();

            ProductManager product = new ProductManager(kernel.Get<IProduct>());
            product.Save();

            Console.ReadLine();
        }
    }
    interface IProduct
    {
        void Save();
    }

    class EfProductDal : IProduct
    {
        public void Save()
        {
            Console.WriteLine("saved with ef");
        }
    }
    class NhProductDal : IProduct
    {
        public void Save()
        {
            Console.WriteLine("saved with nh");
        }
    }

    class ProductManager
    {
        IProduct _product;
        public ProductManager(IProduct product)
        {
            _product = product;
        }

        public void Save()
        {
            _product.Save();
        }
    }
}
