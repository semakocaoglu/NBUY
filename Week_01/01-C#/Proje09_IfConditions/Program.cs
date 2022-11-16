namespace Proje09_IfConditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * if(bool)
             * {
             *      bool true ise yapılacak işler
             * }
             */

            //int sayi = Convert.ToInt32(Console.ReadLine());
            //if (sayi>=0)
            //{
            //    Console.WriteLine("Merhaba dünya!");
            //}

            //Kullanıcıdan yaşını girmesini isteyelim.
            //18 yaşından küçüklere "GİRİŞ YASAK" mesajını yazdıralım.
            //Console.Write("Lütfen yaşınızı giriniz: ");
            //byte yas = Convert.ToByte(Console.ReadLine());
            //if (yas<18)
            //{
            //    Console.WriteLine("Giriş yasak!");
            //}
            //else if (yas>18)
            //{
            //    Console.WriteLine("Giriş serbest");
            //}
            //else
            //{
            //    Console.WriteLine("Velinle birlikte gel!");
            //}

            //Girilen iki sayıdan büyük olanı yazdıralım
            //Console.Write("1.Sayıyı gir: ");
            //int sayi1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("2.Sayıyı gir: ");
            //int sayi2 = Convert.ToInt32(Console.ReadLine());
            //if (sayi1>sayi2)
            //{
            //    Console.WriteLine($"Büyük sayı: {sayi1}");
            //}
            //else if (sayi2>sayi1)
            //{
            //    Console.WriteLine($"Büyük sayı: {sayi2}");
            //}
            //else
            //{
            //    Console.WriteLine($"Sayı 1({sayi1}) ve Sayı 2({sayi2}) birbirlerine eşittir!");
            //}

            //Girilen üç sayıdan büyük olanı yazdıralım
            //Console.Write("1.Sayıyı gir: ");
            //int sayi1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("2.Sayıyı gir: ");
            //int sayi2 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("3.Sayıyı gir: ");
            //int sayi3 = Convert.ToInt32(Console.ReadLine());

            //if (sayi1>=sayi2 && sayi1>=sayi3)
            //{
            //    Console.WriteLine(sayi1);
            //}
            //else if (sayi2>=sayi1 && sayi2>=sayi3)
            //{
            //    Console.WriteLine(sayi2);
            //}
            //else if (sayi3 >= sayi1 && sayi3 >= sayi2)
            //{
            //    Console.WriteLine(sayi3);
            //}


            Console.Write("1.Sayıyı gir: ");
            int sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("2.Sayıyı gir: ");
            int sayi2 = Convert.ToInt32(Console.ReadLine());
            string sonuc = sayi1 > sayi2 ? "1.Sayı 2.Sayıdan büyüktür." : 
                                sayi2 > sayi1 ? "2.Sayı 1.Sayıdan büyüktür." :
                                     "İki sayı birbirine eşittir.";

            //int buyukSayi = sayi1 > sayi2 ? sayi1 : sayi2;
            //Console.WriteLine(buyukSayi);




            //int buyukSayi=0;
            //if (sayi1>sayi2)
            //{
            //    buyukSayi = sayi1;
            //}
            //else if(sayi2>sayi1)
            //{
            //    buyukSayi = sayi2;
            //}
            //Console.WriteLine(buyukSayi);


            




            //Bu doğru olmayan bir algoritma
            //if (sayi1>sayi2)
            //{
            //    if (sayi1>sayi3)
            //    {
            //        Console.WriteLine(sayi1);
            //    }
            //}
            //if(sayi2>sayi1)
            //{
            //    if (sayi2>sayi3)
            //    {
            //        Console.WriteLine(sayi2);
            //    }
            //}
            //if (sayi3>sayi1)
            //{
            //    if (sayi3>sayi2)
            //    {
            //        Console.WriteLine(sayi3);
            //    }
            //}

        }
    }
}