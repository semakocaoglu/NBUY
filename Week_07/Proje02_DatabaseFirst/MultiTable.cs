using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje02_DatabaseFirst.efcore;



namespace Proje02_DatabaseFirst
{
    class CustomerModel
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public int OrderCount { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
    class OrderModel{
        public int OrderId { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }
    }
    public class MultiTable
    {
        public void MusteriSayisi()
        {
            var context = new NorthwindContext();
            var result = context.Customers.Count();
            Console.WriteLine($"{result}");
        }
        public void SatisYapilanMusteriler()
        {

            //Gelen listede her customera ait 
            //id,company name, contact name ve city olacak
            var context = new NorthwindContext();
            var customers = context
                .Customers
                .Where(c => c.Orders.Count() > 0)
                .Select(c => new CustomerModel()
                {
                    CustomerId = c.CustomerId,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    City = c.City
                })
                .ToList();
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.CompanyName}->{c.ContactName}->{c.City}->{c.CustomerId}");
            }

            Console.WriteLine($"Satış Yapılan Müşteri Sayısı: {customers.Count}");
        }


        //Satış yapılmayan müşteri sayısı

        public void SatisYapilmayanMusteriler()
        {

            //Gelen listede her customera ait 
            //id,company name, contact name ve city olacak
            var context = new NorthwindContext();
            var customers = context
                .Customers
                .Where(c => c.Orders.Count() == 0)
                .Select(c => new CustomerModel()
                {
                    CustomerId = c.CustomerId,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    City = c.City
                })
                .ToList();
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.CompanyName}->{c.ContactName}->{c.City}->{c.CustomerId}");
            }

            Console.WriteLine($"Satış Yapılmayan Müşteri Sayısı: {customers.Count}");
        }


        public void MusteriSatisListesi()
        {
            var context = new NorthwindContext();
            var customers = context
                .Customers
                .Select(c=>new CustomerModel(){
                    CustomerId=c.CustomerId,
                    CompanyName=c.CompanyName,
                    ContactName=c.ContactName,
                    City=c.City,
                    OrderCount=c.Orders.Count(),
                    Orders=c.Orders.Select(o=>new OrderModel(){
                        OrderId=o.OrderId,
                        ShippedDate=o.ShippedDate,
                        Freight=o.Freight
                    }).ToList()

                }).ToList();
                foreach (var c in customers)
                {
                    Console.WriteLine($"Id: {c.CustomerId}-Company Name:{c.CompanyName} - Order Count:{c.OrderCount}");
                    foreach (var o in c.Orders)
                    {
                        Console.WriteLine($"\t{o.OrderId} -->{o.ShippedDate}--> {o.Freight}");
                    }
                    Console.WriteLine();
                }

        }
    }
}