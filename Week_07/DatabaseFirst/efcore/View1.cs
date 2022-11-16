using System;
using System.Collections.Generic;

namespace Proje01_DatabaseFirst.efcore
{
    public partial class View1
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
