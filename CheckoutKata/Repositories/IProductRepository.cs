using CheckoutKata.Models;
using System.Collections.Generic;

namespace CheckoutKata.Repositories
{
    public interface IProductRepository
    {
        List<ProductData> GetProducts();
    }
}
