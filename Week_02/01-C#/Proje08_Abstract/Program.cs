namespace Proje08_Abstract
{
    abstract class Person//Eğer bir class abstract ise, o classtan yeni nesne yaratılamaz!
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Console.WriteLine("Person is created!");
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Greeting()
        {
            Console.WriteLine("I am a person.");
        }
        public abstract void Intro();//Soyut metot
        //Eğer bir classın içinde abstract bir metot var ise, o class da abstract olmalı!

    }
    class Student : Person
    {
        public Student(string firstName, string lastName, int studentNumber):base(firstName, lastName)
        {
            StudentNumber = studentNumber;
            Console.WriteLine("Student is created!");
        }
        public int StudentNumber { get; set; }

        public override void Intro()
        {
            Console.WriteLine($"First Name: {FirstName} Last Name: {LastName} Student Number: {StudentNumber}");
        }
    }
    class Teacher: Person
    {
        public Teacher(string firstName, string lastName, string branch):base(firstName, lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Branch = branch;
            Console.WriteLine("Teacher is created!");
        }
        public string Branch { get; set; }

        public override void Intro()
        {
            Console.WriteLine($"First Name: {FirstName} Last Name: {LastName} Branch: {Branch}");
        }

        public void Teach()
        {
            Console.WriteLine("Hi, I am teaching!");
        }
    }
    class Writer: Person
    {
        public Writer(string firstName, string lastName, string bookName):base(firstName,lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            BookName = bookName;
            Console.WriteLine("Writer is created!");
        }
        public string BookName { get; set; }

        public override void Intro()
        {
            Console.WriteLine($"First Name: {FirstName} Last Name: {LastName} Book Name: {BookName}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Ayşen Umay", "Ergül", 101);
            student1.Greeting();
            student1.Intro();//Not: İstemediğimiz halde, Person'daki Intro çalışıyor.

            Teacher teacher1 = new Teacher("Maria", "Canan", "Fizik");
            teacher1.Greeting();
            teacher1.Teach();
            teacher1.Intro();//Not: İstemediğimiz halde, Person'daki Intro çalışıyor.

            Writer writer1 = new Writer("Math", "Haig", "Gece Yarısı Kütüphanesi");
            writer1.Greeting();
            writer1.Intro();

            //Person person1 = new Person("Halil","Kansız"); //abstract olduğu için, new kullanılamaz!
            Console.ReadLine();
        }
    }
}