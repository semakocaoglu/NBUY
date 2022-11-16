namespace Proje11_Collections_GenericList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Intro
            //List<int> sayilar = new List<int>();
            //sayilar.Add(12);
            //sayilar.Add(120);
            //sayilar.Add(69);
            //sayilar.Add(28);
            //sayilar.Add(316);

            //List<string> isimler = new List<string>();
            //isimler.Add("Ali");
            //isimler.Add("Begüm");
            //isimler.Add("Kemal");

            //foreach (var sayi in sayilar)
            //{
            //    Console.WriteLine(sayi);
            //}

            //foreach (var isim in isimler)
            //{
            //    Console.WriteLine(isim);
            //}

            //sayilar.Sort();
            //foreach (var sayi in sayilar)
            //{
            //    Console.WriteLine(sayi);
            //}
            #endregion
            #region FirstSample


            // Product product1 = new Product() { Id = 1, Name = "Bilgisayar", Price = 28000 };
            // Product product2 = new Product() { Id = 2, Name = "Telefon", Price = 18000 };
            // Product product3 = new Product() { Id = 3, Name = "Masa Sandalye Takımı", Price = 8000 };

            // List<Product> products = new List<Product>() { product1, product2, product3 };

            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);




            ////List<Product> products = new List<Product>()
            ////{
            ////    new Product(){Id=1, Name="Telefon", Price=19000},
            ////    new Product(){Id=2, Name="Bilgisayar", Price=39000},
            ////    new Product(){Id=3, Name="Masa Sandalye", Price=9000}
            ////};

            //////Yeni bir liste yaratın. Adı da newProducts olsun. İçine tıpkı yukarıdaki gibi 3 yeni ürün bilgisi girin.

            ////List<Product> newProducts = new List<Product>()
            ////{
            ////    new Product(){Id=4, Name="Mouse", Price=175},
            ////    new Product(){Id=5, Name="Monitör", Price=1750},
            ////    new Product(){Id=6, Name="Buzdolabı", Price=17500}
            ////};

            //////newProducts içindeki productları, products içine ekleyeceğiz.
            ////products.AddRange(newProducts);
            //////products.ForEach(p=>{
            //////    Console.WriteLine($"{p.Name} - {p.Price}");
            //////    Console.WriteLine();
            //////});

            ////int elemanSayisi = products.Count;

            ////products.Insert(0, new Product() { Id = 21, Name = "Gözlük", Price = 1200 });

            ////products.InsertRange(3, newProducts);

            ////foreach (var product in products)
            ////{
            ////    Console.WriteLine($"{product.Name} - {product.Price}");
            ////}





            //List<Product> products = new List<Product>()
            //{
            //    new Product(){Id=1, Name="Telefon", Price=19000},
            //    new Product(){Id=2, Name="Bilgisayar", Price=39000},
            //    new Product(){Id=3, Name="Masa Sandalye", Price=9000}
            //};

            //ProductModel productModel = new ProductModel()
            //{
            //    Id = 1,
            //    CategoryName = "First Category",
            //    Products = products
            //};

            //Console.WriteLine(productModel.CategoryName);
            //foreach (var product in productModel.Products)
            //{
            //    Console.WriteLine($"\t{product.Name}");
            //}
            #endregion

            //İçinde 3 adet ProductModel tipinde veri barındıran bir List oluşturun.
            //Her bir ProductModel içinde ise, Products özelliğine 3'er adet Product koyun.

            List<ProductModel> productModels = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id=1,
                    CategoryName="Bilgisayarlar", 
                    Products= new List<Product>()
                    {
                        new Product(){Id=1,Name="Ürün1",Price=500},
                        new Product(){Id=2,Name="Ürün2",Price=1500},
                        new Product(){Id=3,Name="Ürün3",Price=2500},
                    }
                },
                new ProductModel()
                {
                    Id=21,
                    CategoryName="Telefonlar", 
                    Products= new List<Product>()
                    {
                        new Product(){Id=11,Name="Ürün11",Price=2500},
                        new Product(){Id=12,Name="Ürün22",Price=21500},
                        new Product(){Id=13,Name="Ürün23",Price=22500},
                    }
                },
                new ProductModel()
                {
                    Id=31,
                    CategoryName="Mobilyalar", 
                    Products= new List<Product>()
                    {
                        new Product(){Id=21,Name="Ürün31",Price=3500},
                        new Product(){Id=22,Name="Ürün32",Price=31500},
                        new Product(){Id=23,Name="Ürün33",Price=32500},
                    }
                }
            };


            foreach (var productModel in productModels)
            {
                Console.WriteLine($"Product Model Id: {productModel.Id} - Category Name: {productModel.CategoryName}");
                foreach (var product in productModel.Products)
                {
                    Console.WriteLine($"\tProduct Id: {product.Id} - Product Name: {product.Name} - Product Price: {product.Price}");
                }
                Console.WriteLine("**********************************************************************");
            }

            Console.ReadLine();
        }
    }
}