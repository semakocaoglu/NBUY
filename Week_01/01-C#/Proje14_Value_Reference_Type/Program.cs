using System.Globalization;

namespace Proje14_Value_Reference_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 45;
            int b = a * 2;

            Random rnd = new Random();
            
            Kisi kisi1 = new Kisi();
            kisi1.Ad = "Engin";
            kisi1.Yas = 47;
            kisi1.Meslek = "Software Developer";

            Kisi kisi2 = new Kisi();
            kisi2.Ad = "Saliha";
            kisi2.Yas = 40;
            kisi2.Meslek = "Eğitmen";

            Kisi kisi3 = new Kisi();
            kisi3.Ad = "Cemal";
            kisi3.Yas = 66;
            kisi3.Meslek = "Şair";

            Araba araba1 = new Araba();
            araba1.Marka = "Opel";
            araba1.Renk = "Kırmızı";

            DateTime bugun = DateTime.Now;
            
            Random rnd2 = new Random();
        }
        class Kisi
        {
            public string? Ad { get; set; }
            public int Yas { get; set; }
            public string? Meslek { get; set; }
        }
        class Araba
        {
            public string Marka { get; set; }
            public string Renk { get; set; }
            string VitesTuru { get; set; }
            /*
             * Erişim belirleyici: Bir property'nin dışarıdan yani içinde bulunduğu classın dışından erişim seviyesini belirleyen anahtar sözcüklere denir. Eğer herhangi bir erişim belirleyici kullanılmamışsa, default erişim belirleyici private olarak kabul edilir.
             * Erişim belirleyiciler:
             * 1) public
             * 2) private
             * 3) internal
             * 4) protected
             */ 

        }
    }
}