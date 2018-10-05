using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.save();
            Console.ReadLine();
        }

    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger createLogger()
        {
            // iş geliştirilebilir. loglama göre yeniden oluşturulabilir

            return new OELogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger createLogger()
        {
            // iş geliştirilebilir. loglama göre yeniden oluşturulabilir

            return new Log4Net();
        }
    }
    public interface ILoggerFactory
    {
        ILogger createLogger();
    }
    public interface ILogger
    {
        void log();
    }
    public class OELogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("log with OELogger");
        }
    }
    public class Log4Net : ILogger
    {
        public void log()
        {
            Console.WriteLine("log with Log4Net");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void save()
        {

            Console.WriteLine("saved!");
            ILogger logger = _loggerFactory.createLogger();
            logger.log();
        }
    }
}
