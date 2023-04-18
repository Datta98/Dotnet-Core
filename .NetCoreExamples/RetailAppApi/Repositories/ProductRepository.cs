using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetailAppApi.Data;
using RetailAppApi.Models;

namespace RetailAppApi.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductContext productContext;

        public ProductRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public bool AddProduct(ProductModel product)
        {
            bool status;
            try
            {
                productContext.Product.Add(product);
                productContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool DeleteProduct(int productid)
        {
            bool status;
            try
            {
                ProductModel _productModel = productContext.Product.Find(productid);
                if(_productModel != null)
                {
                    productContext.Product.Remove(_productModel);
                    productContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateProduct(ProductModel product)
        {
            bool status;
            try
            {
                var _product = productContext.Product.Attach(product);
                _product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                productContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        public IEnumerable<ProductModel> GetAllProducts()
        {
            return productContext.Product;
  
        }

    }
}
