using Proje12_OOP_Work_01;
using System.Globalization;

namespace Proje12_OOP_Work_01
{
    interface IBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }
    class Bolum : IBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public List<Ogrenci> Ogrenciler { get; set; }
    }
    class Ogrenci : IBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int OgrNo { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

    }
    internal class Program
    {
        static string GirisYap(string baslik)
        {
            Console.Write(baslik);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            List<Bolum> bolumler = new List<Bolum>();
            for (int i = 0; i < 2; i++)
            {
                Bolum bolum = new Bolum()
                {
                    Id = int.Parse(GirisYap($"{i + 1}.Bölüm Id: ")),
                    Ad = GirisYap($"{i + 1}.Bölümün Adı: "),
                    Aciklama = GirisYap($"{i + 1}.Bölümün Açıklaması: ")
                };
                List<Ogrenci> ogrenciler = new List<Ogrenci>();
                Console.WriteLine($"{bolum.Ad} Bölümü Öğrencileri");
                Console.WriteLine("*******************************");
                for (int j = 0; j < 3; j++)
                {
                    Ogrenci ogrenci = new Ogrenci()
                    {
                        Id = int.Parse(GirisYap($"{j + 1}.Öğrenci Id: ")),
                        OgrNo = int.Parse(GirisYap($"{j + 1}.Öğrenci No: ")),
                        Ad = GirisYap($"{j + 1}.Öğrenci Ad: "),
                        Soyad = GirisYap($"{j + 1}.Öğrenci Soyad: "),
                        Yas = int.Parse(GirisYap($"{j + 1}.Öğrenci Yaş: ")),
                    };
                    ogrenciler.Add(ogrenci);
                    Console.WriteLine("*********************************");
                }
                bolum.Ogrenciler = ogrenciler;
                bolumler.Add(bolum);
                Console.WriteLine("*********************************");
            }
            foreach (var bolum in bolumler)
            {
                Console.WriteLine($"Bölüm Id: {bolum.Id} - Bölüm Ad: {bolum.Ad} - Bölüm Açıklaması: {bolum.Aciklama}");
                foreach (var ogrenci in bolum.Ogrenciler)
                {
                    Console.WriteLine($"Öğrenci Id: {ogrenci.Id} - Öğrenci No: {ogrenci.OgrNo} - Öğrenci Ad Soyad: {ogrenci.Ad} {ogrenci.Soyad} - Öğrenci Yaş: {ogrenci.Yas}");
                }
            }
            
            Console.ReadLine();
        }
    }
}





//Console.Write($"{i + 1}.Bölüm Id: ");
//bolum.Id = int.Parse(Console.ReadLine());
//Console.Write($"{i + 1}.Bölümün Adı: ");
//bolum.Ad = Console.ReadLine();
//Console.Write($"{i + 1}.Bölümün Açıklaması: ");
//bolum.Aciklama = Console.ReadLine();