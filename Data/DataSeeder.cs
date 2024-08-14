using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data
{
    public static class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new EcommerceContext(
                serviceProvider.GetRequiredService<DbContextOptions<EcommerceContext>>());

            if (context.Products.Any())
            {
                return; // DB has been seeded
            }

            var categories = new List<Category>
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Books" }
            };

            var products = new List<Product>
            {
                new Product { Name = "Laptop", Description = "A high-performance laptop", Price = 1200.99M, Category = categories[0] },
                new Product { Name = "Smartphone", Description = "Latest model smartphone", Price = 799.99M, Category = categories[0] },
                new Product { Name = "Science Fiction Novel", Description = "A gripping sci-fi novel", Price = 19.99M, Category = categories[1] }
            };

            var users = new List<User>
            {
                new User { UserName = "johndoe", Email = "johndoe@example.com", Password = "password123" },
                new User { UserName = "janedoe", Email = "janedoe@example.com", Password = "password123" }
            };

            context.Categories.AddRange(categories);
            context.Products.AddRange(products);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
