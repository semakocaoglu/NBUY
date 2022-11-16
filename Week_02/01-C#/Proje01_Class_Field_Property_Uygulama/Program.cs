using System.Diagnostics;
using System.Xml.Linq;

namespace Proje01_Class_Field_Property_Uygulama
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Product classımız olacak: Name, Price, Description
            //İstenildiği kadar Product bilgisinin girilmesini sağlayacağız.
            //Kaç adet Product bilgisi girileceğini kullanıcı belirlesin.
            //Product ekleme işi bitince, eklenmiş Product'lar listelensin.
            #region FirstSolve
            //Console.Write("Kaç adet ürün gireceksiniz?: ");
            //int adet = int.Parse(Console.ReadLine());
            //Product[] products = new Product[adet];
            //Product product;
            //for (int i = 0; i < adet; i++)
            //{
            //    product = new Product();

            //    Console.Write("Product Name: ");
            //    product.Name = Console.ReadLine();

            //    Console.Write("Price: ");
            //    product.Price = decimal.Parse(Console.ReadLine());

            //    Console.Write("Description: ");
            //    product.Description = Console.ReadLine();

            //    products[i] = product;
            //}
            //Console.WriteLine("Product Name\tPrice\tDescription");
            //foreach (var prd in products)
            //{
            //    Console.WriteLine($"{prd.Name}\t{prd.Price}\t{prd.Description}");
            //}
            #endregion

            #region SecondSolve
            //Console.Write("Kaç adet ürün gireceksiniz?: ");
            //Product[] products = new Product[5];
            //string[] names = { "iPhone 13", "Dell", "Casper Excalibur", "Vestel TV", "Kablosuz Mouse" };
            //string[] descriptions = { "İyi", "Harika", "Güzel", "Heyecan verici", "Şaşırtıcı" };

            //Product product;
            //Random rnd = new Random();
            //for (int i = 0; i < 5; i++)
            //{
            //    product = new Product();
            //    product.Name = names[rnd.Next(0, 5)];
            //    product.Price = rnd.Next(100, 10001);
            //    product.Description = descriptions[rnd.Next(0, 5)];
            //    products[i] = product;
            //}
            //Console.WriteLine("Product Name\tPrice\tDescription");
            //foreach (var prd in products)
            //{
            //    Console.WriteLine($"{prd.Name}\t{prd.Price} TL\t{prd.Description}");
            //}
            #endregion

            #region RastgeleDegerUreterek
            Product[] products = new Product[5];
            Product product;
            string[] nameArray = { "Galaxy A50", "HP Notebook", "MacBook Air M2", "Iphone 14 Plus", "LG 27 inç Monitör" };
            string[] descArray = { "İyidir", "Şaşırtıcıdır", "Heyecan vericidir", "Soluğunuzu keser", "Tırttır" };
            decimal[] oldPrices = new decimal[5];
            Random random = new Random();
            Console.WriteLine("Yapılacak zam oranını giriniz: ");
            decimal oran = decimal.Parse(Console.ReadLine());
            for (int i = 0; i < 5; i++)
            {
                product = new Product()
                {
                    Name = nameArray[random.Next(0, 5)],
                    Description = descArray[random.Next(0, 5)],
                    Price = random.Next(100, 1001)
                };
                oldPrices[i] = product.Price;
                product.Price *= (1 + (oran / 100));
                products[i] = product;
            }

            Console.WriteLine("Product Name".PadRight(30) + "Old Price".PadRight(10) + "Price".PadRight(10) + "Description");
            int j = 0;
            foreach (var prd in products)
            {
                Console.WriteLine($"{prd.Name.PadRight(30)}{oldPrices[j].ToString().PadRight(10)} {prd.Price.ToString().PadRight(10)}{prd.Description}");
                j++;
            }
            #endregion


        }
    }


}