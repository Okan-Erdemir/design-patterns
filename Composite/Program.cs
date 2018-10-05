using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {  // nesneler arası hiyararji ve istenilen zaman ulaşabilme
        static void Main(string[] args)
        {
            Employee okan = new Employee() { Name = "okan erdemir" };
            Employee salih = new Employee() { Name = "salih uçan" };
            okan.AddSubordinate(salih);
            Employee derin = new Employee() { Name = "derin uçan" };
            okan.AddSubordinate(derin);
            Contractor ali = new Contractor() { Name = "ali" };
            derin.AddSubordinate(ali);
            Employee ahmet = new Employee() { Name = "ahmet uçan" };
            salih.AddSubordinate(ahmet);
            Console.WriteLine(okan.Name);
            foreach (Employee manager in okan)
            {
                Console.WriteLine("  " + manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    " + employee.Name);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }


    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var item in _subordinates)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
