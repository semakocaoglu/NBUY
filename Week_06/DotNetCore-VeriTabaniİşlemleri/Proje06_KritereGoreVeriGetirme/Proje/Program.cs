using System.Data.SqlClient;
using Proje.BusinessLayer;
using Proje.DataAccessLayer;
using Proje.DataAccessLayer.Entities;

namespace Proje;
class Program
{
    static void Main(string[] args)
    {
        int secim;
        do
        {
            Console.Clear();
            Console.WriteLine("Choose Database->");
            Console.WriteLine("1-MsSql");
            Console.WriteLine("2-Sqlite");
            Console.WriteLine("0-Exit");
            Console.Write("Lütfen seçiminizi giriniz: ");
            secim = int.Parse(Console.ReadLine());
            if (secim == 1)
            {
                Menu(secim);
                Console.ReadLine();
            }
            else if (secim == 2)
            {
                Menu(secim);
                Console.ReadLine();
            }
            else if (secim != 0)
            {
                Console.WriteLine("Lütfen geçerli bir seçim yapınız!");
            }

        } while (secim != 0);
    }
    static void Menu(int dbType)
    {
        Console.Clear();
        string dbName = dbType == 1 ? "MsSql" : "SqLite";
        Console.WriteLine($"By {dbName} Database - Northwind");
        Console.WriteLine("-----------------------------");
        Console.WriteLine("1-Product List");
        Console.WriteLine("2-Customer List");
        if (dbType == 1)
        {
            Console.WriteLine("3-Search product by id");
            Console.WriteLine("4-Filter product by category id");
            Console.WriteLine("5-Filter product by category name");
        }
        Console.Write("Seçiminizi yapınız: ");
        int secim = int.Parse(Console.ReadLine());
        if (secim == 1)
        {
            if (dbType == 1)
            {
                ProductList(new SqlProductDAL());
            }
            else
            {
                ProductList(new SqliteProductDAL());
            }
        }
        else if (secim == 2)
        {
            if (dbType == 1)
            {
                CustomerList(new SqlCustomerDAL());
            }
            else
            {
                CustomerList(new SqliteCustomerDAL());
            }
        }
        else if (secim == 3)
        {
            if (dbType == 1)
            {
                ProductSearch(new SqlProductDAL());
            }
            else
            {

            }
        }
        else if (secim == 4)
        {
            if (dbType == 1)
            {
                ProductsFilterByCategoryId(new SqlProductDAL());
            }
            else
            {

            }
        }
        else if (secim == 5)
        {
            if (dbType == 1)
            {
                ProductsFilterByCategory(new SqlProductDAL());
            }
            else
            {

            }
        }
    }
    static void ProductsFilterByCategory(IProductDAL productDal)
    {
        var productManager = new ProductManager(productDal);
        Console.Write("Enter Category Name: ");
        string catName = Console.ReadLine();
        List<Product> products = productManager.GetProductsByCategory(catName);
        if (products.Count > 0)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            }
        }
        else
        {
            Console.WriteLine("Aradığınız kategoride ürün yoktur!");
        }

    }
    static void ProductsFilterByCategoryId(IProductDAL productDal)
    {
        var productManager = new ProductManager(productDal);
        Console.Write("Enter Category Id: ");
        int catId = int.Parse(Console.ReadLine());
        List<Product> products = productManager.GetProductsByCategoryId(catId);
        if (products.Count > 0)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            }
        }
        else
        {
            Console.WriteLine("Aradığınız kategoride ürün yoktur!");
        }

    }
    static void ProductSearch(IProductDAL productDAL)
    {
        var productManager = new ProductManager(productDAL);
        Console.Write("Enter id: ");
        int id = int.Parse(Console.ReadLine());
        Product product = productManager.GetByIdProduct(id);
        if (product != null)
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
        }
        else
        {
            Console.WriteLine("No product!");
        }

        Console.ReadLine();
    }
    static void ProductList(IProductDAL productDAL)
    {
        var productManager = new ProductManager(productDAL);
        List<Product> products = productManager.GetAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
        }
    }
    static void CustomerList(ICustomerDAL customerDAL)
    {
        var customerManager = new CustomerManager(customerDAL);
        List<Customer> customers = customerManager.GetAllCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine($"Id: {customer.Id}, Company: {customer.Company}, City: {customer.City}, Country: {customer.Country}");
        }
    }
}
