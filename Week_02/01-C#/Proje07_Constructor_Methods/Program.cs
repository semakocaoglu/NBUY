namespace Proje07_Constructor_Methods
{
    class Person
    {
        public Person()//Method, Constructor Method-TİPİ OLMAZ!
        {
            //Her classın default olarak boş bir constructor methodu vardır, ama implicittir, yani örtülü, gizlidir. Şu anda biz kendimiz bir constructor method yazdık!
            //Constructor method, ilgili classtan new keywordü ile yeni bir nesne yaratıldığı esnada çalışacak kodları barındırır.
            //Yani, bu classtan bir nesne üretildiği anda buradaki kodlar çalışır!
            Console.WriteLine("Merhaba, ben Person, şu an yaratıldım!");
        }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    class Student : Person
    {
        public Student(string firstName, string lastName, int studentNumber):base(firstName, lastName)
        {
            StudentNumber = studentNumber;
        }
        public int StudentNumber { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person1 = new Person();
            //Person person2 = new Person("Engin Niyazi", "Ergül");
            //Console.WriteLine($"{person2.FirstName} {person2.LastName}");


            Student student1 = new Student("Selin","Candaş",345);
            Console.WriteLine($"{student1.FirstName} {student1.LastName} {student1.StudentNumber}");
            Console.ReadLine();
        }
    }
}