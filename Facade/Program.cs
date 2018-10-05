using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager();
            customerManager.save();
            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void log();
    }

    class Caching : ICache
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICache
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Authorized");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Validate : IValidate
    {
        public void Validation()
        {
            Console.WriteLine("Validated");
        }
    }

    internal interface IValidate
    {
        void Validation();
    }

    class CustomerManager
    {
        CrossCuttingConcernsFacade _crossCuttingConcernsFacade;
        public CustomerManager()
        {
            _crossCuttingConcernsFacade = new CrossCuttingConcernsFacade();
        }
        public void save()
        {
            _crossCuttingConcernsFacade._cache.Cache();
            _crossCuttingConcernsFacade._logging.log();
            _crossCuttingConcernsFacade._authorize.CheckUser();
            _crossCuttingConcernsFacade._validate.Validation();
            Console.WriteLine("saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging _logging;
        public ICache _cache;
        public IAuthorize _authorize;
        public IValidate _validate;

        public CrossCuttingConcernsFacade()
        {
            _logging = new Logging();
            _cache = new Caching();
            _authorize = new Authorize();
            _validate = new Validate();
        }
    }

}
