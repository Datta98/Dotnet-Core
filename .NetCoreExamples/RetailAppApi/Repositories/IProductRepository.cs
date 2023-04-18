using RetailAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailAppApi.Repositories
{
    public interface IProductRepository
    {

        bool AddProduct(ProductModel product);
        bool DeleteProduct(int productid);
        bool UpdateProduct(ProductModel product);
        IEnumerable<ProductModel> GetAllProducts();
    }
}
