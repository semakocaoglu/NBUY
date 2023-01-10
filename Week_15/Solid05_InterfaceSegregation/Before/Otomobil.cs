using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.Before
{
    public class IOtomobil : IOtomobil
    {
        public int KapiSayisi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UretimYili { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int KapiSayisiniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double MotorGucunuGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string YakitTipiniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string IletimTipiniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IletimHiziniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
