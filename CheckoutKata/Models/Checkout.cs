using CheckoutKata.Models.Interfaces;
using System;
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
            decimal totalPrice;
            var sku = "a";
            var product = _product.Products.First(x => x.SKU == sku);

            var timesScanned = ProductCheckoutList.First(x => x.SKU == sku).TimesScanned;
            var specialPriceItemPairs = Convert.ToInt32(Math.Floor(Convert.ToDouble(timesScanned / product.SpecialPriceQuantity)));

            if (specialPriceItemPairs > 0)
            {
                totalPrice = specialPriceItemPairs * product.SpecialPrice;
                var nonSpecialPriceItems = timesScanned - product.SpecialPriceQuantity * specialPriceItemPairs;

                if (nonSpecialPriceItems > 0)
                    totalPrice += nonSpecialPriceItems * product.UnitPrice;
            }
            else
            {
                totalPrice = product.UnitPrice * timesScanned;
            }
            var price = ProductCheckoutList.Any(x => x.SKU == "b") && ProductCheckoutList.First(x => x.SKU == "b").TimesScanned > 0 ? _product.Products.First(x => x.SKU == "b").UnitPrice : 0;
            return totalPrice + price;
        }
    }
}