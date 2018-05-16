using Microsoft.EntityFrameworkCore;
 
namespace WeddingApp.Models
{
    public class WeddingContext : DbContext
    {
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Wedding> Weddings {get;set;}
        public DbSet <Attendance> Attendance {get;set;}
    }
}