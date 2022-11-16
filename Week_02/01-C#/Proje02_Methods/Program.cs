namespace Proje02_Methods
{
    public class Program
    {
        //static void Topla(int sayi1,int sayi2)
        //{
        //    int toplam = sayi1 + sayi2;
        //    Console.WriteLine();
        //    Console.WriteLine($"Toplam: {toplam}");
        //}
        //static void Cikar(int sayi1, int sayi2)
        //{
        //    int fark = sayi1 - sayi2;
        //    Console.WriteLine();
        //    Console.WriteLine($"Fark: {fark}");
        //}
        //public static int Topla(int sayi1, int sayi2)
        //{
        //    return sayi1 + sayi2;
        //}
        static int Cikar(int sayi1, int sayi2)
        {
            int fark = sayi1 - sayi2;
            return fark;
        }
        static int SiraNoBul(string metin, char karakter)
        {
            int sonuc = metin.IndexOf(karakter);
            return sonuc;
        }
        static bool VarMi(string metin, char karakter)
        {
            bool sonuc = metin.Contains(karakter);
            return sonuc;
        }
        static void Main(string[] args) //METHOD
        {
            #region ToplamaCikarma
            //Console.Write("Birinci Sayı: ");
            //int s1 = int.Parse(Console.ReadLine());
            //Console.Write("İkinci Sayı: ");
            //int s2 = int.Parse(Console.ReadLine());

            //int toplam = Topla(s1, s2);
            //int fark = Cikar(s1, s2);

            //Console.WriteLine($"Toplam: {toplam}, Fark: {fark}");
            //Console.WriteLine($"{toplam-fark}");
            #endregion
            #region IndexOfMuadiliMetot
            //Kendisine verilen metnin içinde, aradığımız karakterin kaçıncı sırada olduğunu bulan metodu hazırlayınız.
            //Console.WriteLine(SiraNoBul("Wissen Akademie",'A'));
            #endregion
            #region ContainsMuadiliMetot
            //Kendisine verilen metnin içinde, aradığımız karakterin OLUP OLMADIĞINI bize söyleyen bir metodu hazırlayınız.
            //Console.WriteLine(VarMi("Wissen Akademie",'A')==true ? "İçinde geçiyor" : "İçinde geçmiyor");
            #endregion

            #region MethodOverloads
            MethodOverload methodOverload = new MethodOverload();

            //Console.WriteLine(methodOverload.Topla(55, 66));
            Console.WriteLine(methodOverload.Islem(50, 10,5));
            int[] sayilar = { 56, 44, 66, 77, 89, 100, 200, 300 };
            Console.WriteLine(methodOverload.Topla(sayilar));
            #endregion


        }
    }
}