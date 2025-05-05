using Microsoft.EntityFrameworkCore;

namespace Jwt_CURD_Operation.ModelClasses
{
    public class AppDbcontex:DbContext
    {
        public AppDbcontex(DbContextOptions<AppDbcontex> options):base(options) { }

        public DbSet<Product> Product1 { get; set; }
        public DbSet<User> users { get; set; } 
    }
}
