using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<OrderDB> Orders { get; set; }
        public DbSet<OrderArticle> Articles { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QRI4V36\SQLEXPRESS;Database=asp-test;Trusted_Connection=True;");
        }
    }
}
