using Products.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Products.API.DbContexts
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
           : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "Category 1"
               },
               new Product
               {
                   Id = 2,
                   Name = "category 2"
               }
               );

            // seed the database with dummy data
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "product 1",
                    Price = 10.5,
                    Quantity = 15,
                    ImgURL = "",
                    CateogryID = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "product 2",
                    Price = 15,
                    Quantity = 35,
                    ImgURL = "",
                    CateogryID = 1
                },
                new Product()
                {
                    Id = 3,
                    Name = "product 3",
                    Price = 150,
                    Quantity = 1,
                    ImgURL = "",
                    CateogryID = 2
                },
                new Product()
                {
                    Id = 4,
                    Name = "product 4",
                    Price = 300.40,
                    Quantity = 30,
                    ImgURL = "",
                    CateogryID = 1
                },
                new Product()
                {
                    Id = 5,
                    Name = "product 5",
                    Price = 1000,
                    Quantity = 300,
                    ImgURL = "",
                    CateogryID = 2
                }
                );



            base.OnModelCreating(modelBuilder);
        }
    }
}
