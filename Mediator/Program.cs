using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator);
            teacher.Name = "Okan";
            mediator.Teacher = teacher;

            Student student1 = new Student(mediator);
            student1.Name = "cenk";
            Student student2 = new Student(mediator);
            student2.Name = "mecnun";

            mediator.Students = new List<Student>();
            mediator.Students.Add(student1);
            mediator.Students.Add(student2);

            teacher.SendNewImageUrl("slide1.jpg");
            teacher.RecieveQuestion("is it true", student1);


            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {

        protected Mediator _mediator;
        protected CourseMember(Mediator mediator)
        {
            _mediator = mediator;
        }

    }

    internal class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("teacher recieved a question from {0} , {1}", student.Name, question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("teacher change slide : {0}", url);
            _mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("teacher answered question {0},{1}", student.Name, answer);
        }
    }

    internal class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received {0}", url, Name);
        }

        public void RecieveAnswer(string answer, Student student)
        {
            Console.WriteLine("student received answer {0}", answer);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {

            foreach (var item in Students)
            {
                item.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }
        public void SendAsnwer(string answer, Student student)
        {
            student.RecieveAnswer(answer, student);

        }
    }
}
