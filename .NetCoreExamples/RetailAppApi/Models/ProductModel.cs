
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailAppApi.Models
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }

        public decimal Price { get; set; }
        public decimal Offer { get; set; }

        public int Quantity { get; set; }
    }
}
