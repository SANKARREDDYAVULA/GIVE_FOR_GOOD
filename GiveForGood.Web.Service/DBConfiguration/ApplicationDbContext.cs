using GiveForGood.Web.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace GiveForGood.Web.Service.DBConfiguration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Role> roles { get; set; }
    }
}
