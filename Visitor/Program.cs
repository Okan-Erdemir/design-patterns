using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Genel olarak birbirine benziyen ve hiyerarşi nesnelerin aynı methodunun biri üzerinden çağırılması.*/

            Manager manager1 = new Manager { Name = "okan", Salary = 1000 };
            Manager manager2 = new Manager { Name = "cenk", Salary = 900 };
            Worker worker = new Worker { Name = "Eleman", Salary = 500 };
            Worker worker1 = new Worker { Name = "Eleman1", Salary = 500 };
            Worker worker2 = new Worker { Name = "Eleman2", Salary = 500 };

            manager1.Subordinates.Add(worker);
            manager1.Subordinates.Add(worker1);
            manager2.Subordinates.Add(worker2);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(manager1);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payrise = new Payrise();
            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payrise);



            Console.ReadLine();
        }
        class OrganisationalStructure
        {
            public EmployeeBase _employee;
            public OrganisationalStructure(EmployeeBase firstEmployeeBase)
            {
                _employee = firstEmployeeBase;
            }

            public void Accept(VisitorBase visitor)
            {
                _employee.Accept(visitor);
            }
        }
        abstract class EmployeeBase
        {
            public abstract void Accept(VisitorBase visitor);
            public string Name { get; set; }
            public decimal Salary { get; set; }
        }
        class Manager : EmployeeBase
        {
            public List<EmployeeBase> Subordinates { get; set; }
            public Manager()
            {
                Subordinates = new List<EmployeeBase>();
            }


            public override void Accept(VisitorBase visitor)
            {
                visitor.Visit(this);
                foreach (var item in Subordinates)
                {
                    item.Accept(visitor);
                }
            }
        }
        class Worker : EmployeeBase
        {
            public override void Accept(VisitorBase visitor)
            {
                visitor.Visit(this);
            }
        }

        abstract class VisitorBase
        {
            public abstract void Visit(Worker worker);
            public abstract void Visit(Manager manager);
        }
        class PayrollVisitor : VisitorBase
        {
            public override void Visit(Worker worker)
            {
                Console.WriteLine("Worker: {0} paid {1}", worker.Name, worker.Salary);
            }

            public override void Visit(Manager manager)
            {
                Console.WriteLine("Manager: {0} paid {1}", manager.Name, manager.Salary);
            }
        }

        class Payrise : VisitorBase
        {
            public override void Visit(Worker worker)
            {
                Console.WriteLine("Manager: {0} salary increased to {1}", worker.Name, worker.Salary * (decimal)1.1);
            }

            public override void Visit(Manager manager)
            {
                Console.WriteLine("Manager: {0} salary increased to {1}", manager.Name, manager.Salary * (decimal)1.2);
            }
        }
    }
}
