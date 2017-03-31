using CheckoutKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        private List<Product> _products;

        [TestMethod]
        public void ScanOneItem()
        {
            string sku = "a";
            var checkout = new Checkout();

            checkout.Scan(sku);

            var productCheckout = checkout.ProductCheckoutList.FirstOrDefault(x => x.SKU == sku);
            Assert.IsNotNull(productCheckout);
            Assert.AreEqual(1, productCheckout.TimesScanned);
        }
    }
}
