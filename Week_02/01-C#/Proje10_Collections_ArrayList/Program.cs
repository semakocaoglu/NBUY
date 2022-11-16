using System.Collections;
namespace Proje10_Collections_ArrayList
{
    internal class Program
    {
        static void Yazdir(ArrayList arrayList)
        {
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            ArrayList sayilar = new ArrayList() { 54, 12, 66, 34, 19 };
            Console.WriteLine("Default Sıra");
            Yazdir(sayilar);
            sayilar.Sort();
            Console.WriteLine("*********");
            Console.WriteLine("Küçükten büyüğe sıralı");
            Yazdir(sayilar);
            sayilar.Sort();
            Console.WriteLine("*********");
            Console.WriteLine("Büyükten küçüğe sıralı");
            sayilar.Reverse();
            Yazdir(sayilar);


            //ArrayList myList = new ArrayList();

            //myList.Add(120);
            //myList.Add("120");
            //myList.Add("Zeynep");
            //myList.Add(11.5);
            //myList.Add(DateTime.Now);
            //myList.Add(true);


            //myList.Insert(0, "Yeni eleman");

            //ArrayList addedList = new ArrayList() { "Ayşen Umay", "Fercan Sercan", "Kazım Kolkanat" };

            //myList.InsertRange(4, addedList);
            //myList.AddRange(addedList);

            //myList.Remove("Zeynep");
            ////myList.RemoveAt(0);
            ////myList.RemoveRange(0, 3);


            //foreach (var item in myList)
            //{
            //    Console.WriteLine(item);
            //}
            //if (myList.Contains("Zeynep")==true)
            //{
            //    Console.WriteLine("Evet, Zeynep listede mevcut!");
            //}
            //else
            //{
            //    Console.WriteLine("Acil, Zeynep'e haber ver! Listede yok!");
            //}


            //Console.WriteLine();
            ////Console.WriteLine(myList[3]);

            Console.ReadLine();
        }
    }
}