﻿namespace Proje03_DegiskenOrnekleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int sayi1 = 120;
            //int sayi2 = 110;
            //Console.WriteLine(sayi1 + "\n" + sayi2);
            //Console.WriteLine($"SAYI1: {sayi1}\nSAYI2: {sayi2}");
            //Console.WriteLine(sayi1.ToString() + sayi2.ToString());

            //string sayi3 = "120";
            //int sayi4 = 110;
            //Console.WriteLine(Convert.ToInt32(sayi3) + sayi4);


            decimal sayi1 = 0.1m;
            decimal sayi2 = 0.7m;
            decimal sayi3 = 0.8m;
            Console.WriteLine(sayi1);
            Console.WriteLine(sayi2);
            Console.WriteLine(sayi3);

            Console.WriteLine(sayi1+sayi2);
            Console.WriteLine((sayi1+sayi2) == sayi3);
        }
    }
}