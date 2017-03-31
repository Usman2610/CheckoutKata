using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Models
{
    public class Checkout
    {
        public List<ProductCheckout> ProductCheckoutList { get; set; }
        public decimal TotalPrice { get; set; }

        public Checkout()
        {
            ProductCheckoutList = ProductCheckoutList ?? new List<ProductCheckout>();
        }

        public void Scan(string product)
        {
            ProductCheckoutList.Add(new ProductCheckout { SKU = product, TimesScanned = 1 });
        }
    }
}