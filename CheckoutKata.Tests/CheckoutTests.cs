using CheckoutKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        private Checkout _checkout;

        [TestInitialize]
        public void Initialization()
        {
            _checkout = new Checkout();
        }

        [TestMethod]
        public void WhenIScanOneItemThenItShouldBeAddedToTheProductCheckout()
        {
            string sku = "a";

            _checkout.Scan(sku);

            var productCheckout = _checkout.ProductCheckoutList.FirstOrDefault(x => x.SKU == sku);
            Assert.IsNotNull(productCheckout);
            Assert.AreEqual(1, productCheckout.TimesScanned);
        }

        [TestMethod]
        public void WhenIScanTwoItemThenTheyShouldBeAddedToTheProductCheckout()
        {
            string sku = "a";

            _checkout.Scan(sku);
            _checkout.Scan(sku);

            var productCheckout = _checkout.ProductCheckoutList.FirstOrDefault(x => x.SKU == sku);
            Assert.IsNotNull(productCheckout);
            Assert.AreEqual(2, productCheckout.TimesScanned);
        }
    }
}
