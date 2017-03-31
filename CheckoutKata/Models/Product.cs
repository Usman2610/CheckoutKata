using System.Collections.Generic;

namespace CheckoutKata.Models
{
    public class ProductData
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public int SpecialPriceQuantity { get; set; }
    }

    public class Product
    {
        public List<ProductData> Products { get; set; }

        public Product()
        {
            Products = new List<ProductData>();
            var a = new ProductData
            {
                SKU = "a",
                UnitPrice = 50,
                SpecialPrice = 130,
                SpecialPriceQuantity = 3
            };

            Products.Add(a);

            var b = new ProductData
            {
                SKU = "b",
                UnitPrice = 30,
                SpecialPrice = 45,
                SpecialPriceQuantity = 2
            };

            Products.Add(b);

            var c = new ProductData
            {
                SKU = "a",
                UnitPrice = 20,
                SpecialPrice = 0,
                SpecialPriceQuantity = 0
            };

            Products.Add(c);

            var d = new ProductData
            {
                SKU = "a",
                UnitPrice = 15,
                SpecialPrice = 0,
                SpecialPriceQuantity = 0
            };

            Products.Add(d);
        }
    }
}