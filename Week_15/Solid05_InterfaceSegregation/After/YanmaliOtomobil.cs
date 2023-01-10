using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.After
{
    public class YanmaliOtomobil : IOtomobilOrtak ,IYanmaliMotor
    {
        public int KapisayisiniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UretimiliniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double MotorGucunuGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string YakitTipiniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
