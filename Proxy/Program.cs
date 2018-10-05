using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        // bir cacheleme sistemine benzetebiliriz. sınıfın çağırdığı işlemi  ikinci kez çağırılmış sa, daha önce ki işlemden kalan sonucu çağırma yöntemidir.
        static void Main(string[] args)
        {
            CreditBase creditManagerProxy = new CreditManagerProxy();
            Console.WriteLine(creditManagerProxy.Calculate());
            Console.WriteLine(creditManagerProxy.Calculate());
            Console.ReadLine();
        }

        abstract class CreditBase
        {
            public abstract int Calculate();
        }

        class CreditManager : CreditBase
        {
            public override int Calculate()
            {
                int result = 1;
                for (int i = 1; i < 5; i++)
                {
                    result *= i;
                    Thread.Sleep(500);
                }
                return result;
            }
        }

        class CreditManagerProxy : CreditBase
        {

            CreditManager _creditManager;
            int _cachedValue;

            public override int Calculate()
            {
                if (_creditManager == null)
                {
                    _creditManager = new CreditManager();
                    _cachedValue = _creditManager.Calculate();
                }

                return _cachedValue;
            }
        }
    }
}
