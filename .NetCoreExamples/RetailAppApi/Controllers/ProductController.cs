using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetailAppApi.Repositories;
using RetailAppApi.Models;
namespace RetailAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController (IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public string Validate(Boolean isValid)
        {
            if(isValid==true)
            {
                return "Sucessfully";
            }
            else
            {
                return "Failed";
            }
        }
       
        [HttpPost]
        public string AddProduct([FromBody] ProductModel _product)
        {
            Boolean isSuccess = productRepository.AddProduct(_product);
            string msg = Validate(isSuccess);
            return "Inserting"+" "+_product.Name+" "+_product.CategoryName+" "+ msg;
        }


        [HttpPut]
        public string UpdateProduct([FromBody] ProductModel _product)
        {
            Boolean isSuccess = productRepository.UpdateProduct(_product);
            string msg = Validate(isSuccess);
            return "Updated" + msg;

        }

        [HttpDelete]
        public string DeleteProduct(int productid)
        {
            Boolean isSuccess = productRepository.DeleteProduct(productid);
            string msg = Validate(isSuccess);
            return "Deleted" + msg;
        }

        [HttpGet]
        public IEnumerable<string> GetAllProducts()
        {
            IEnumerable<string> products = productRepository.GetAllProducts().Select(product => product.Name).ToList();


            return products;
        }

        [Route("ProductById/{Id}")]

        public ProductModel GetProductById(int id)
        {
            return productRepository.GetAllProducts().Where(product => product.ID == id).FirstOrDefault();
        }

    }
}
