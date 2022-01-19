using Microsoft.EntityFrameworkCore;
using WebApiDependency.Models;

namespace WebApiDependency.Data
{
    public class UserContext: DbContext {
    public UserContext(DbContextOptions<UserContext> options) : base(options) 
    {
       
    }  

    public DbSet<UserModel> AccountsUser { get; set; }
    
}
    
       
}
