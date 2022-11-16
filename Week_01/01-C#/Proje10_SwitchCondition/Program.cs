namespace Proje10_SwitchCondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Klavyeden girilen sayının 5 olması halinde 2 katını , 10 olması halinde 3 katını ya da 15 olması halinde ise 4 katını 
            //ekrana yazan programı hazırlayalım. Eğer üçü de değilse Tanınmayan Değer yazsın.

            //Console.Write("Lütfen bir sayı giriniz(5-10-15): ");
            //int sayi = Convert.ToInt32(Console.ReadLine());
            //int sonuc = 0;
            //switch (sayi)
            //{
            //    case 5:
            //        sonuc = sayi * 2;
            //        break;
            //    case 10:
            //        sonuc = sayi * 3;
            //        break;
            //    case 15:
            //        sonuc = sayi * 4;
            //        break;
            //    default:
            //        sonuc = 0;
            //        break;
            //}

            //if (sonuc==0)
            //{
            //    Console.WriteLine("Tanımlanmamış değer");
            //}
            //else
            //{
            //    Console.WriteLine(sonuc);
            //}





            //if (sayi==5)
            //{
            //    sonuc = sayi * 2;
            //}
            //else if(sayi==10)
            //{
            //    sonuc = sayi * 3;
            //}
            //else if(sayi==15)
            //{
            //    sonuc = sayi * 4;
            //}

            //if (sonuc==0)
            //{
            //    Console.WriteLine("Tanımlanmamış değer!");
            //}
            //else
            //{
            //    Console.WriteLine(sonuc);
            //}




            //x-> <10 ->    2 ile çarp
            //x-> 11-20->   3 ile çarp
            //x-> 21-50->   4 ile çarp
            //x-> 51-100->  5 ile çarp
            //x-> >100 ->   10 ile çarp

            //Çözüm1: IF ile

            //int x = 120;
            //int katsayi = 0;
            //if (x<=10)
            //{
            //    katsayi = 2;
            //}
            //else if (x<=20)
            //{
            //    katsayi = 3;
            //}
            //else if (x<=50)
            //{
            //    katsayi = 4;
            //}
            //else if (x<=100)
            //{
            //    katsayi = 5;
            //}
            //else
            //{
            //    katsayi = 10;
            //}
            //int sonuc = x * katsayi;
            //Console.WriteLine($"X: {x}, Sonuç: {sonuc}");//X:25, Sonuç:100
            ////X:25, Sonuç: 25x4=100
            ////X:150, Sonuç: 150x10=1500


            //int x = 45;
            //int katsayi = 0;
            //switch (x)
            //{
            //    case (>=0 and <=10):
            //        katsayi = 2;
            //        break;
            //    case (>=11 and <=20):
            //        katsayi = 3;
            //        break;
            //    case (>= 21 and <= 50):
            //        katsayi= 4;
            //        break;
            //    case (>= 51 and <= 100):
            //        katsayi = 5;
            //        break;
            //    default:
            //        katsayi = 6;
            //        break;
            //}
            //int sonuc = x * katsayi;
            //Console.WriteLine($"X: {x}, Sonuç: {x} x {katsayi} : {sonuc}");


            //İçinde bulunduğumuz günün hafta içi mi yoksa hafta sonu mu olduğunu bulalım

            DateTime tarih = new DateTime(2022, 10, 8);
            DayOfWeek gun = tarih.DayOfWeek;

            //if (gun==DayOfWeek.Sunday || gun==DayOfWeek.Saturday)
            //{
            //    Console.WriteLine("Hafta sonundasın, haydi gez eğlen!");
            //}
            //else
            //{
            //    Console.WriteLine("Hafta içindesin, çalış, çalış, çalış!");
            //}

            //switch (gun)
            //{

            //    case DayOfWeek.Monday: case DayOfWeek.Tuesday: case DayOfWeek.Wednesday: case DayOfWeek.Thursday:
            //    case DayOfWeek.Friday:
            //        Console.WriteLine("Hafta içindesin, üzgünüm, çalışmalısın!");
            //        break;
            //    case DayOfWeek.Saturday:
            //    case DayOfWeek.Sunday:
            //        Console.WriteLine("Hafta sonu gelmiş, gez ve mutlaka dinlen!");
            //        break;
            //    default:
            //        break;
            //}

            switch (gun)
            {

                case DayOfWeek.Monday or 
                        DayOfWeek.Tuesday or 
                        DayOfWeek.Wednesday or 
                        DayOfWeek.Thursday or 
                        DayOfWeek.Friday:
                    Console.WriteLine("Hafta içindesin, üzgünüm, çalışmalısın!");
                    break;
                case DayOfWeek.Saturday or DayOfWeek.Sunday:
                    Console.WriteLine("Hafta sonu gelmiş, gez ve mutlaka dinlen!");
                    break;
                default:
                    break;
            }
        }
    }
}