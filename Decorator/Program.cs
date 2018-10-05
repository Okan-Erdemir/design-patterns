using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // temel bir nesneye farklı koşullarda daha farklı anlamlar  yüklemek için kullanılan design patterndir.

            var personalCar = new PersonalCar() { Make = "BMW", Model = "3.20d", HirePrice = 2500 };

            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DisCountPercentage = 10;
            Console.WriteLine("Concrete : " + personalCar.HirePrice);
            Console.WriteLine("special offer : " + specialOffer.HirePrice);


            Console.ReadLine();
        }

        abstract class CarBase
        {
            public abstract string Make { get; set; }
            public abstract string Model { get; set; }
            public abstract decimal HirePrice { get; set; }
        }

        class PersonalCar : CarBase
        {
            public override string Make { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }
        class CommercialCar : CarBase
        {
            public override string Make { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }

        abstract class CarDecoratorBase : CarBase
        {
            CarBase _carBase;
            public CarDecoratorBase(CarBase carBase)
            {
                _carBase = carBase;
            }
        }
        class SpecialOffer : CarDecoratorBase
        {

            public int DisCountPercentage { get; set; }

            private readonly CarBase _carBase;
            public SpecialOffer(CarBase carBase) : base(carBase)
            {
                _carBase = carBase;
            }
            public override string Make { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice
            {
                get
                {
                    return _carBase.HirePrice - _carBase.HirePrice * DisCountPercentage / 100;
                }
                set
                {

                }
            }
        }
    }
}
