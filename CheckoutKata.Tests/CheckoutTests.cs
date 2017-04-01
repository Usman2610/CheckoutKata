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

        [TestMethod]
        public void WhenIScanMultipleItemsThenTheyShouldBeAddedToTheProductCheckout()
        {
            string sku = "a";
            string b = "b";

            _checkout.Scan(sku);
            _checkout.Scan(b);

            var productCheckoutItemA = _checkout.ProductCheckoutList.FirstOrDefault(x => x.SKU == sku);
            var productCheckoutItemB = _checkout.ProductCheckoutList.FirstOrDefault(x => x.SKU == b);
            Assert.IsNotNull(productCheckoutItemA);
            Assert.AreEqual(1, productCheckoutItemA.TimesScanned);
            Assert.IsNotNull(productCheckoutItemB);
            Assert.AreEqual(1, productCheckoutItemB.TimesScanned);
        }

        [TestMethod]
        public void WhenIScanMultipleItemsInADifferentOrderMultipleTimesThenTheyShouldBeAddedToTheProductCheckout()
        {
            string sku = "a";
            string b = "b";

            _checkout.Scan(sku);
            _checkout.Scan(b);
            _checkout.Scan(sku);
            _checkout.Scan(b);
            _checkout.Scan(sku);

            var productCheckoutItemA = _checkout.ProductCheckoutList.FirstOrDefault(x => x.SKU == sku);
            var productCheckoutItemB = _checkout.ProductCheckoutList.FirstOrDefault(x => x.SKU == b);
            Assert.IsNotNull(productCheckoutItemA);
            Assert.AreEqual(3, productCheckoutItemA.TimesScanned);
            Assert.IsNotNull(productCheckoutItemB);
            Assert.AreEqual(2, productCheckoutItemB.TimesScanned);
        }

        [TestMethod]
        public void WhenIScanOneItemThenTheTotalPriceShoulBeUpdated()
        {
            string sku = "a";

            _checkout.Scan(sku);
            var totalPrice = _checkout.GetTotalPrice();
            
            Assert.AreEqual(50, totalPrice);
        }

        [TestMethod]
        public void WhenIScanTwoItemsThenTheTotalPriceShoulBeUpdated()
        {
            string sku = "a";

            _checkout.Scan(sku);
            _checkout.Scan(sku);
            var totalPrice = _checkout.GetTotalPrice();

            Assert.AreEqual(100, totalPrice);
        }

        [TestMethod]
        public void WhenIScanThreeOfTheSameItemsThenTheTotalPriceShoulBeTheSpecialPrice()
        {
            string sku = "a";

            _checkout.Scan(sku);
            _checkout.Scan(sku);
            _checkout.Scan(sku);
            var totalPrice = _checkout.GetTotalPrice();

            Assert.AreEqual(130, totalPrice);
        }
    }
}
