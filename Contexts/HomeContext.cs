using Microsoft.EntityFrameworkCore;

namespace LifeBalance.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions options) : base(options){}

        public DbSet<User> users {get; set;}

        public DbSet<Values> Values {get; set;}
        
    }
}