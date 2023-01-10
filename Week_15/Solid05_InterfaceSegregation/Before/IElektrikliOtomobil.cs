using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.Before
{
    public interface IElektrikliOtomobil
    {
        public string BataraTip { get; set; }
        public string BataryaTipiniGetir { get; set; }
        public decimal VoltajDegeriniGetir { get; set; }


    }
}
