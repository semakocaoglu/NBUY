using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.Before
{
    public interface IOtomobil
    {
        public int KapiSayisi { get; set; }
        public int UretimYili { get; set; }
        public int KapiSayisiniGetir { get; set; }
        public double MotorGucunuGetir { get; set; }
        public string YakitTipiniGetir { get; set; }
        public string IletimTipiniGetir { get; set; }
        public int IletimHiziniGetir { get; set; }
    }
}
