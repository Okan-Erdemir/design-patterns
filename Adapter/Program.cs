using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        // farklı sistemlerin kendi sistemlerimize entegre edilmesi durumda kendi sistemimizin bozulmadan farklı sistemin bizim sistemimizmiş gibi davranmasını diyebiliriz.
        static void Main(string[] args)
        {

            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();

        }
    }

    class ProductManager
    {
        ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;

        }
        public void Save()
        {
            _logger.Log("User data");
            Console.WriteLine("saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class OELogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"logged -  {message}");
        }
    }

    //nugetten dll olarak geldi.
    class Log4Net
    {
        public void Log(string message)
        {
            Console.WriteLine($"log4net -  {message}");
        }
    }


    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.Log(message);

        }
    }
}
