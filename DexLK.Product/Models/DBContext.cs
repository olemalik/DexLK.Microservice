using Microsoft.EntityFrameworkCore;
using DexLK.Product.Models;

namespace DexLK.Product.Model.DBContexts
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Models.Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

       /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category
                 {
                     Id = 1,
                     Name = "Electronics",
                     Description = "Electronic Items",
                 },
                 new Category
                 {
                     Id = 2,
                     Name = "Clothes",
                     Description = "Dresses",
                 },
                 new Category
                 {
                     Id = 3,
                     Name = "Grocery",
                     Description = "Grocery Items",
                 }
             );
                 
        }*/

    }
}
