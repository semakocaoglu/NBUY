namespace Proje11_For
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"{i+1}.Hello, World!");
            //}

            //int toplam = 0;
            //for (int i = 1; i <= 10; i++)
            //{
            //    //toplam = toplam + i;
            //    toplam += i;
            //}
            //Console.WriteLine($"Toplam: {toplam}");

            //1-10 arasındaki çift sayıların toplamını buldurun
            //modüler bölme : %
            //    10/5=2
            //    10%2=0

            //int toplam = 0;
            //for (int i = 0; i <= 10; i=i+2)
            //{
            //    toplam += i;
            //}
            //Console.WriteLine(toplam);

            //int toplam = 0;
            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i%2==0) toplam += i;
            //}
            //Console.WriteLine(toplam);

            //1-10 arasındaki çift sayıların toplamını ayrı, tek sayıların toplamını ayrı gösteren kodu yazınız.
            //int ciftToplam = 0;
            //int tekToplam = 0;
            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i % 2 != 0)
            //    {
            //        tekToplam += i;
            //    }
            //    else
            //    {
            //        ciftToplam += i;
            //    }
            //}
            //Console.WriteLine($"Tek sayıların toplamı: {tekToplam}\nÇift sayıların toplamı: {ciftToplam}");


            //SORU: Klavyeden iki sayı girilsin. Bu sayıların arasındaki sayıların toplamını ekrana yazdıralım.
            //Console.Write("1.Sayıyı giriniz: ");
            //int sayi1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("2.Sayıyı giriniz: ");
            //int sayi2 = Convert.ToInt32(Console.ReadLine());
            //int toplam = 0;

            //for (int i = sayi1; i <= sayi2; i++)
            //{
            //    toplam += i;
            //}
            //Console.WriteLine($"Toplam: {toplam}");


            //Console.Write("1.Sayıyı giriniz: ");
            //int sayi1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("2.Sayıyı giriniz: ");
            //int sayi2 = Convert.ToInt32(Console.ReadLine());
            //int toplam = 0;

            //if (sayi2>sayi1)
            //{
            //    for (int i = sayi1; i <= sayi2; i++)
            //    {
            //        toplam += i;
            //    }
            //}
            //else
            //{
            //    for (int i = sayi1; i >= sayi2; i--)
            //    {
            //        toplam += i;
            //    }
            //}
            //Console.WriteLine($"Toplam: {toplam}");


            //Console.Write("1.Sayıyı giriniz: ");
            //int sayi1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("2.Sayıyı giriniz: ");
            //int sayi2 = Convert.ToInt32(Console.ReadLine());
            //int toplam = 0;
            //int min = Math.Min(sayi1, sayi2);
            //int max = Math.Max(sayi1, sayi2);

            //for (int i = min; i <= max; i++)
            //{
            //    toplam += i;
            //}
            //Console.WriteLine($"Toplam: {toplam}");


            //SORU: Program kullanıcıdan bir sayı girmesini istesin. Ancak kullanıcı sayı girmeye devam ettikçe girilen sayıların toplanmasını sağlayalım. SAYI ADEDİ BELİRSİZDİR! Uygulamanın bitip, ekrana toplamı yazdırabilmesi için kullanıcının sayı yerine exit yazmasını kontrol edeceğiz.

            //int toplam = 0;
            //string girilenDeger = "";
            //string sonucMetin = "";
            //string sonEk = "+";
            //for (int i = 1; i < 1000000; i++)
            //{
            //    Console.Write($"{i}. sayıyı giriniz(Çıkış için exit)[Geçerli toplam: {toplam}]: ");
            //    girilenDeger = Console.ReadLine();
            //    if (girilenDeger.ToLower()=="exit")//if küçük BÜYÜK hard duyarlıdır!
            //    {
            //        break;//içinde bulunulan döngünün, tamamlanmasını beklemeden, istenilen bir anda durdurulması için kullanılır.
            //    }
            //    sonucMetin = sonucMetin + girilenDeger + sonEk;

            //    toplam += Convert.ToInt32(girilenDeger);

            //}
            //int alinacakKisminUzunlugu = sonucMetin.Length - sonEk.Length;
            //sonucMetin = sonucMetin.Substring(0, alinacakKisminUzunlugu);
            //Console.WriteLine($"{sonucMetin} = {toplam}");


            ////SORU: 5x5'lik bir kare biçimini * işaretleriyle oluşturan uygulamayı yazınız.
            ///*
            // *    *****
            // *    *****
            // *    *****
            // *    *****
            // *    *****
            // */
            //int satir = 5;
            //int sutun = 5;
            //for (int i = 0; i < satir; i++)
            //{
            //    //A
            //    for (int j = 0; j < sutun; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}



            //SORU: 5x5'lik bir içi BOŞ kare biçimini * işaretleriyle oluşturan uygulamayı yazınız.
            /*
             *    *****
             *    *   *
             *    *   *
             *    *   *
             *    *****
             */
            int satir = 5;
            int sutun = 5;
            for (int i = 1; i <= satir; i++)
            {
                //A
                for (int j = 1; j <= sutun; j++)
                {
                    if (i==1 || i==satir)//eğer 1. veya son satırdaysan
                    {
                        Console.Write("*");
                    }
                    else if (j==1 || j==sutun)//eğer 1. veya son sütundaysan
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            //ÖDEV: Üstteki içi boş kareyi oluşturan uygulamayı ADIM ADIM çalıştırarak anlamaya çalışın.
            //ÖDEV-1: 1-100 arasındaki sayıların ortalamasını bulduran program.
            //ÖDEV-2: 1-100 arasındaki çift, tek ve 5'in katı olan sayıların adetleri ve toplamlarını ekrana yazdıran program.
            //ÖDEV-3: Aşağıdaki yüksekliği 5, tabanı 9 birim olan yıldızlardan oluşan dik üçgeni çizdiren program.
            /*
             * *
             * ***
             * *****
             * *******
             * *********
             */

             
        }
    }
}