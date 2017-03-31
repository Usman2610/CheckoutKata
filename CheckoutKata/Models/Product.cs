using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutKata.Models
{
    public class Product
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public int SpecialPriceQuantity { get; set; }
        public int TimesScanned { get; set; }
    }
}