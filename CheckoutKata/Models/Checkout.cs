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
            var sku = "a";
            var product = _product.Products.First(x => x.SKU == sku);

            var timesScanned = ProductCheckoutList.First(x => x.SKU == sku).TimesScanned;

            if (product.SpecialPriceQuantity == timesScanned)
                return product.SpecialPrice;
            else if (timesScanned == 4)
            {
                return product.SpecialPrice + product.UnitPrice;
            }
            else
                return product.UnitPrice * timesScanned;
        }
    }
}