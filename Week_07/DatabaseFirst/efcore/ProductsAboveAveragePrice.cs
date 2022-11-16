using System;
using System.Collections.Generic;

namespace Proje01_DatabaseFirst.efcore
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
