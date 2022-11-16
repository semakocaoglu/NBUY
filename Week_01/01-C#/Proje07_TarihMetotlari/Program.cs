namespace Proje07_TarihMetotlari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine(DateTime.Today);

            //DateTime dogumTarihi = new DateTime(1975, 7, 16); //16.07.1975
            //DateTime bugun = DateTime.Now;
            //TimeSpan span = bugun.Subtract(dogumTarihi);
            //Console.WriteLine($"Toplam {Math.Ceiling(span.TotalDays)} gündür yaşıyorsunuz!");

            //DateTime bugun = DateTime.Now;
            //Console.WriteLine(bugun.ToLongDateString());//5 Ekim 2022 Çarşamba
            //Console.WriteLine(bugun.ToLongTimeString());//13:35:30
            //Console.WriteLine(bugun.ToShortDateString());//5.10.2022
            //Console.WriteLine(bugun.ToShortTimeString());//13:35

            //Bir sonraki yılın ilk gününün tarihini bulduralım
            //DateTime bugun = DateTime.Now;
            //int yil = bugun.Year + 1;
            //DateTime sonuc = new DateTime(yil, 1, 1);
            //Console.WriteLine(sonuc.ToLongDateString());


            //Bir sonraki ayın ilk gününün tarihini bulduralım
            //DateTime bugun = DateTime.Now;
            //int yil = bugun.Year;
            //int ay = bugun.Month+1;
            //DateTime sonuc = new DateTime(yil, ay, 1);
            //Console.WriteLine(sonuc);

            DateTime bugun = DateTime.Now;
            //Console.WriteLine(bugun + 1);

            /*
             * 
             * Ö    D    E    V
             * Ertesi günün tarihini bulup ekrana yazdıran programı yazınız.
             */
        }
    }
}