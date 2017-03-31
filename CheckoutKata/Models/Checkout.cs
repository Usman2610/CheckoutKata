using System;
using System.Collections.Generic;

namespace CheckoutKata.Models
{
    public class Checkout
    {
        public List<ProductCheckout> ProductCheckoutList { get; set; }
        public decimal TotalPrice { get; set; }

        public void Scan(string product)
        {
            ProductCheckoutList = new List<ProductCheckout>();
            ProductCheckoutList.Add(new ProductCheckout { SKU = "a", TimesScanned = 1 });
        }
    }
}