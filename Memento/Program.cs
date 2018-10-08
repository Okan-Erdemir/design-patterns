using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book()
            {
                Isbn = "12345",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.Showbook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();
            book.Isbn = "54321";
            book.Author= "Okan ERDEMİR";
            book.Showbook();
            book.RestoreFromUndo(history.Memento);
            book.Showbook();
            Console.ReadLine();

        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        DateTime _lastedited;


        public string Title { get { return _title; } set { _title = value; SetLastEdited(); } }
        public string Author { get { return _author; } set { _author = value; SetLastEdited(); } }
        public string Isbn { get { return _isbn; } set { _isbn = value; SetLastEdited(); } }

        private void SetLastEdited()
        {
            _lastedited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {

            return new Memento(_isbn, _title, _author, _lastedited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _lastedited = memento.LastEdited;
            _isbn = memento.Isbn;
        }

        public void Showbook()
        {
            Console.WriteLine("{0} , {1} , {2} edited : {3} ", Isbn, Title, Author, _lastedited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string title, string author, DateTime lastedited)
        {
            isbn = Isbn;
            title = Title;
            Author = author;
            lastedited = LastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }

    }

}
