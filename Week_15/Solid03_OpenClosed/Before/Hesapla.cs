using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03_OpenClosed.Before
{
    public class Hesapla
    {
        //Bu metot kendisine gelen şekillerin alanlarnn toplamını bulacak.
        public double AlanlariTopla(object[] sekiller)
        {
            double alanToplami = 0;
            foreach(var sekil in sekiller)
            {
                if (sekil is Kare)
                {
                    alanToplami += Math.Pow(((Kare)sekil).Kenar,2);
                }
                else if(sekil is Daire)
                {
                    alanToplami += Math.PI + Math.Pow(((Daire)sekil).yaricap, 2);
                }
                else
                {

                }
            }
            return alanToplami;
        }
    }
}
