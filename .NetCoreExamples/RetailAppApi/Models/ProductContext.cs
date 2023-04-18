
using Microsoft.EntityFrameworkCore;
using RetailAppApi.Models;

namespace RetailAppApi.Data
{
    public class ProductContext : DbContext   {

        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
            
        }

        public DbSet<ProductModel> Product { get; set; }
    }
    
 }

