namespace Proje05_MetinselMetotlar;
class Program
{
    static void Main(string[] args)
    {
        //Bu projede metinsel işlemlere dair bazı metotlar öğreneceğiz
        //string metin = "Wissen Akademie";
        //int uzunluk = metin.Length;
        ////Console.WriteLine($"Uzunluk: {uzunluk}");
        //Console.WriteLine($"{metin} metni {uzunluk} karakterdir.");

        //string metin = "WİSSEN";
        //string kucukMetin = metin.ToLower();
        //Console.WriteLine(kucukMetin);
        //string buyukMetin = kucukMetin.ToUpper();
        //Console.WriteLine(buyukMetin);

        //string m1 = "Wissen";
        //string m2 = "Wissen";
        //int sonuc = String.Compare(m1, m2);
        //Console.WriteLine(m1);
        //Console.WriteLine(m2);
        //Console.WriteLine(sonuc);

        //Console.Write("1.Metni giriniz: ");
        //string m1 = Console.ReadLine();
        //Console.Write("2.Metni giriniz: ");
        //string m2 = Console.ReadLine();
        //int sonuc = String.Compare(m1, m2);
        //if (sonuc==0)
        //{
        //    Console.WriteLine("Girilen iki metin birbirine EŞİTTİR!");
        //}
        //else
        //{
        //    Console.WriteLine("Girilen iki metin birbirinden FARKLIDIR!");
        //}


        //string m1 = "İşKur";
        //string m2 = "Eğitimleri";
        //string m3 = "Wissen";
        ////string sonuc = m1 + m2 + m3;
        //string sonuc = String.Concat(m1, m2, m3);
        //Console.WriteLine(sonuc);


        //string ad = "Engin";
        //int yas = 47;
        //string okul = "BAU";
        /*
         * Benim adım Engin. 47 yaşındayım. Okuduğum okulun adı BAU.
         * 1) + operatörü ile
         * 2) Concat ile
         * 3) $"" ile 
         */

        ////Çözüm-1
        //string sonuc1 = "Benim adım " + ad + ". " + yas + " yaşındayım. Okuduğum okulun adı " + okul;
        //Console.WriteLine(sonuc1);
        ////Çözüm-2
        //string sonuc2 = String.Concat("Benim adım ", ad, ". ", yas, " yaşındayım. Okuduğum okulun adı ", okul); 
        //Console.WriteLine(sonuc2);
        ////Çözüm-3
        //string sonuc3 = $"Benim adım {ad}. {yas} yaşındayım. Okuduğum okulun adı {okul}";
        //Console.WriteLine(sonuc3);
        //string metin = "Merhaba. Bu hafta eğitime başladık.";
        //bool sonuc = metin.Contains(" ");
        //Console.WriteLine(sonuc);
        //string adres = "İstanbul şehit Ali mh. Can sk. No:6 Kadıköy/Ankara";
        //bool sonuc = adres.EndsWith("İstanbul");
        //bool sonuc2 = adres.StartsWith("İstanbul");
        //Console.WriteLine(sonuc + ", " + sonuc2);

        //adres içindeki C harfi kaçıncı sıradadır?

        //string aranacakIfade = "Ş";

        //int siraNo = adres.ToUpper().IndexOf(aranacakIfade.ToUpper());
        //Console.WriteLine($"C harfi {adres} içinde, {siraNo}.sıradadır.");


        //string aranacakIfade = "ŞeHiT aLi";

        //int siraNo = adres.ToUpper().IndexOf(aranacakIfade.ToUpper());
        //Console.WriteLine($"{aranacakIfade} ifadesi {adres} içinde, {siraNo}.sıradadır.");

        //string metin = "Wissen Akademie";
        //Console.WriteLine($"Metnin ilk hali: {metin}");
        //Console.WriteLine($"Akademie ifadesi silindikten sonraki hali: {metin.Remove(7)}");
        //Console.WriteLine($"Aka ifadesi silindikten sonraki hali: {metin.Remove(7,3)}");

        string urunAd = "IPhone 13 Pro";
        //iphone-13-pro
        //string sonuc = (urunAd.Replace(" ", "-")).ToLower();
        string sonuc = urunAd.ToLower().Replace(" ", "-");
        Console.WriteLine(sonuc);
        string sonuc2 = urunAd.Replace("IPhone", "Samsung");
        Console.WriteLine(sonuc2);

    }
}
