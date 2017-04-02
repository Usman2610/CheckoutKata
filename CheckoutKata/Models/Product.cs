using CheckoutKata.Repositories;
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
            var productRepository = new ProductRepository();
            Products = productRepository.GetProducts();
        }
    }
}