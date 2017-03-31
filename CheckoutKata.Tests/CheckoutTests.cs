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

            checkout.Scan(product);

            var product = _products.FirstOrDefault(x => x.SKU == sku);
            Assert.IsNotNull(product);
            Assert.AreEqual(1, product.TimesScanned);
        }
    }
}
