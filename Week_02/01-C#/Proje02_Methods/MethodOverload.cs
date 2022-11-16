using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje02_Methods
{
    public class MethodOverload
    {
        private int price; //Field
        public int Price //Property
        {
            get { return price; }
            set { price = value; }
        }
        public int Sayi { get; set; } //Property
        public string Name { get; set; } //Property
        //public void DenemeMetodu()//Method
        //{
        //    Console.WriteLine("Merhaba. Ben MethodOverload classındayım!");
        //    Console.WriteLine(Program.Topla(3, 5));
        //}

        public int Topla(int s1, int s2, int s3=0)
        {
            return s1 + s2 + s3;
        }
        //Gönderilen üç sayı arasında istersem toplama, istersem çarpma yapsın.
        public int Islem(int s1, int s2, int s3 = 0, bool islemTuru=true)
        {
            if (islemTuru == true)
            {
                return s1 + s2 + s3;
            }
            else
            {
                if (s3 == 0) s3 = 1;
                return s1 * s2 * s3;
            }
            
        }
        public int Topla(int[] sayilar)
        {
            int sonuc = sayilar.Sum();
            return sonuc;
        }

    }
    
   
}
