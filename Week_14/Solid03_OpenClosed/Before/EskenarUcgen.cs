using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03_OpenClosed.Before
{
    public class EskenarUcgen
    {
        public EskenarUcgen(int kenar)
        {
            Kenar = kenar;
        }

        public int Kenar { get; set; }
        public int Yukseklik { get; set; }  
    }
}
