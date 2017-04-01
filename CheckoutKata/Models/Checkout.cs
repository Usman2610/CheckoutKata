using CheckoutKata.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Models
{
    public class Checkout : ICheckout
    {
        public List<ProductCheckout> ProductCheckoutList { get; set; }
        private Product _product { get; set; }

        public Checkout()
        {
            ProductCheckoutList = ProductCheckoutList ?? new List<ProductCheckout>();
            _product = _product ?? new Product();
        }

        public void Scan(string product)
        {
            var productCheckout = ProductCheckoutList.Find(x => x.SKU == product);

            if (productCheckout != null)
                productCheckout.TimesScanned += 1;
            else
                ProductCheckoutList.Add(new ProductCheckout { SKU = product, TimesScanned = 1 });
        }

        public decimal GetTotalPrice()
        {
            var timesScanned = ProductCheckoutList.First(x => x.SKU == "a").TimesScanned;
            return _product.Products.First(x => x.SKU == "a").UnitPrice * timesScanned;
        }
    }
}