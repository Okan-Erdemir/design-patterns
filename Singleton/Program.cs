using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                var customerManager = CustomManager.createAsSingleton();
                Console.WriteLine(customerManager.GetGuid());

            }
            Console.ReadLine();
        }
        class CustomManager
        {
            private static CustomManager _customerManager;
            static object _lockObject = new object();
            // instance almasını engelliyoruz.
            private CustomManager()
            {

            }

            // singleton oluşma bölümü oluşmamış ise geri dönüyor.
            public static CustomManager createAsSingleton()
            {
                lock (_lockObject)
                {
                    if (_customerManager == null)
                    {
                        _customerManager = new CustomManager();
                    }
                }

                return _customerManager;
            }

            // ISS başlatıldıktan sonra ISS restart atılıncaya kadar değişmeyecek method.
            public string GetGuid()
            {
                return Guid.NewGuid().ToString();
            }

        }
    }
}
