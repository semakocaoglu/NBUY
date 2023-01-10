using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.After
{
    public class ElektrikliOtomobil : IOtomobilOrtak, IElektrikliMotor
    {
        public int KapisayisiniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UretimiliniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BataryaTipiniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal VoltajDegeriniGetir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
