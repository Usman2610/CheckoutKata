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
            decimal totalPrice = 0;
            var productCheckoutList = ProductCheckoutList.Where(x => x.TimesScanned > 0).ToList();

            foreach (var productCheckout in productCheckoutList)
            {
                var product = _product.Products.First(x => x.SKU == productCheckout.SKU);
                var specialPriceItemPairs = Convert.ToInt32(Math.Floor(Convert.ToDouble(productCheckout.TimesScanned / product.SpecialPriceQuantity)));

                if (specialPriceItemPairs > 0)
                {
                    totalPrice += specialPriceItemPairs * product.SpecialPrice;
                    var nonSpecialPriceItems = productCheckout.TimesScanned - product.SpecialPriceQuantity * specialPriceItemPairs;

                    if (nonSpecialPriceItems > 0)
                        totalPrice += nonSpecialPriceItems * product.UnitPrice;
                }
                else
                {
                    totalPrice += product.UnitPrice * productCheckout.TimesScanned;
                }
            }

            return totalPrice;
        }
    }
}