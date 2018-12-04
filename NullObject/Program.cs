using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        private Ilogger _Ilogger;
        public CustomerManager(Ilogger Ilogger)
        {
            _Ilogger = Ilogger;


        }

        public void Save()
        {
            Console.WriteLine("saved");
            _Ilogger.Log();
        }


    }

    interface Ilogger
    {
        void Log();
    }

    class Log4NetLogger : Ilogger
    {
        public void Log()
        {
            Console.WriteLine("log for Log4Net");
        }
    }
    class NLogLogger : Ilogger
    {
        public void Log()
        {
            Console.WriteLine("log for NLog");
        }
    }

    class StubLogger : Ilogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();

        private StubLogger() { }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger = new StubLogger();
                }

            }
            return _stubLogger;
        }
        public void Log()
        {

            
        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }

}
