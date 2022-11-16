using Proje01_DatabaseFirst.efcore;

namespace Proje01_DatabaseFirst;
class Program
{
    static void Main(string[] args)
    {
        NorthwindContext context = new NorthwindContext();
        List<Customer> customers = context.Customers.ToList();
        foreach (var c in customers)
        {
            Console.WriteLine(c.CompanyName);
        }
    }
}
