using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    class Program
    {
        static void Main(string[] args)
        {
            // yeni referans maliyetinden kurtulduk.Sadece belli özellik değiştiği zaman kullanılır.
            Customer customer = new Customer()
            {
                FirstName = "okan",
                LastName = "erdemir",
                City = "kastamonu",
                Id = 1
            };

            Customer customer2 = (Customer)customer.Clone();
            customer2.FirstName = "Salih";



            Console.WriteLine(customer.FirstName);
            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Customer : Person
    {
        //Person clone alıp "new" olaylarını minimum a indirmemizi sağlıyor performans için gereklidir.
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public decimal Salary { get; set; }


        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
