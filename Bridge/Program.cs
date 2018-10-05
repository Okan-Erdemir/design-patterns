using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new SMSSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved");
        }
        public abstract void Send(Body body);
    }

    class Body
    {

        public string Title { get; set; }
        public string Text { get; set; }
    }
    class SMSSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body);
        }
    }

    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender", body);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }

        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body { Title="About The course!"});

            Console.WriteLine("Customer Updated");
        }
    }

    class NewCustomerManager :CustomerManager
    {

    }
}
