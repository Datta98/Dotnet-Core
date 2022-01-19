using System.ComponentModel.DataAnnotations;

namespace WebApiDependency.Models
{
    public class UserModel
    {
        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string EmailId { get; set; }
    }

}