using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckoutKata.Models;

namespace CheckoutKata.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductData> GetProducts()
        {
            var products = new List<ProductData>();
            var a = new ProductData
            {
                SKU = "a",
                UnitPrice = 50,
                SpecialPrice = 130,
                SpecialPriceQuantity = 3
            };

            products.Add(a);

            var b = new ProductData
            {
                SKU = "b",
                UnitPrice = 30,
                SpecialPrice = 45,
                SpecialPriceQuantity = 2
            };

            products.Add(b);

            var c = new ProductData
            {
                SKU = "c",
                UnitPrice = 20,
                SpecialPrice = 0,
                SpecialPriceQuantity = 0
            };

            products.Add(c);

            var d = new ProductData
            {
                SKU = "d",
                UnitPrice = 15,
                SpecialPrice = 0,
                SpecialPriceQuantity = 0
            };

            products.Add(d);

            return products;
        }
    }
}