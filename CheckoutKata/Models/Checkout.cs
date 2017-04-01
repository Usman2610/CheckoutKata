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
            var productCheckout = ProductCheckoutList.Find(x => x.SKU == product);

            if (productCheckout != null)
                productCheckout.TimesScanned += 1;
            else
                ProductCheckoutList.Add(new ProductCheckout { SKU = product, TimesScanned = 1 });
        }
    }
}