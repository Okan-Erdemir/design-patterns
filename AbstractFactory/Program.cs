using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager _productManager = new ProductManager(new Factory2());
            _productManager.GetAll();
            Console.ReadLine();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }
    public class Nlogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Nlogger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging createLogger();
        public abstract Caching createCaching();
    }
    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching createCaching()
        {
            return new RedisCache();
        }

        public override Logging createLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching createCaching()
        {
            return new RedisCache();
        }

        public override Logging createLogger()
        {
            return new Nlogger();
        }
    }
    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.createLogger();
            _caching = _crossCuttingConcernsFactory.createCaching();
        }


        public void GetAll()
        {
            _logging.Log("log");
            _caching.Cache("data");
            Console.WriteLine("Products listed!");
        }
    }
}
