using BFF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace BFF.Core.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=PostgreSQL 15; host=localhost; port=5432; database=OrangeCat; username=postgres; pwd=Kay1s.yapar;");
        }
    }
}
