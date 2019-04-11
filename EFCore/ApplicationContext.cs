using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<OrderDB> Orders { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QRI4V36\SQLEXPRESS;Database=TestAsp;Trusted_Connection=True;");
        }
    }
}
