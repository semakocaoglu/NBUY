namespace Proje02_Degiskenler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bir değişkene isim verirken;
            //1) Alfanümerik karakterler kullanılmaz.(alt tire (_) hariç)
            //2) Türkçe karakter kullanılmaz.(Zorunlu değil)
            //3) Özel ya da ayrılmış sözcükler kullanılmaz.
            //4) Değişken isimleri küçük büyük harf duyarlıdır.

            /* Burası comment */
            /*
            string adSoyad;
            adSoyad = "Alex de Souza";
            Console.WriteLine(adSoyad);
            Console.WriteLine("adSoyad");
            */

            //int yas;
            //yas = 19;
            //Console.WriteLine(yas);

            //string adSoyad = "Ahmet Candan";
            //Console.WriteLine(adSoyad);

            //Console.WriteLine("Adı:" + adSoyad + ", Yaş:" + yas);


            //TAM SAYI
            //Console.WriteLine(int.MinValue + "-" + int.MaxValue);
            
            byte sayi1 = 255;
            //int sayi2 = 4587868688767868;
            long sayi3 = 12548789786546;

            //    string sayi4 = "15";
            //    Console.WriteLine(sayi4+2);

            //ONDALIKLI
            float a = 10.5f;
            double b = 20.6;
            decimal c = 100.65m;

            //KARAKTER ve METİN
            string name = "Engin Niyazi Ergül";
            char cinsiyet = 'E';

            //MANTIKSAL
            bool evliMi = true;
            evliMi = false;

        }
    }
}