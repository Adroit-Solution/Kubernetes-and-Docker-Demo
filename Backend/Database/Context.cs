using DockerDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo.Database;

public class ApplicationDbContext : DbContext
{

    Guid electronicsId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    Guid booksId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    Guid clothingId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    Guid homeId = Guid.Parse("44444444-4444-4444-4444-444444444444");
    Guid toysId = Guid.Parse("55555555-5555-5555-5555-555555555555");

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = electronicsId,
                Name = "Electronics",
                Description = "Devices, gadgets and accessories"
            },
            new Category
            {
                Id = booksId,
                Name = "Books",
                Description = "Printed and digital books across genres"
            },
            new Category
            {
                Id = clothingId,
                Name = "Clothing",
                Description = "Men's and women's apparel"
            },
            new Category
            {
                Id = homeId,
                Name = "Home",
                Description = "Home goods, decor and kitchenware"
            },
            new Category
            {
                Id = toysId,
                Name = "Toys",
                Description = "Toys, games and children's products"
            }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Wireless Headphones",
                Description = "Over-ear, noise-cancelling headphones with long battery life.",
                Price = 129.99m,
                CategoryId = electronicsId
            },
            new Product
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Name = "Smartphone Charger",
                Description = "Fast-charge USB-C wall adapter, 30W.",
                Price = 19.99m,
                CategoryId = electronicsId
            },
            new Product
            {
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                Name = "Modern C# Programming",
                Description = "Comprehensive guide to modern C# and .NET development.",
                Price = 39.95m,
                CategoryId = booksId
            },
            new Product
            {
                Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                Name = "Children's Picture Book",
                Description = "Illustrated storybook for ages 3-7.",
                Price = 12.50m,
                CategoryId = booksId
            },
            new Product
            {
                Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                Name = "Men's Casual T-Shirt",
                Description = "100% cotton, regular fit.",
                Price = 24.00m,
                CategoryId = clothingId
            },
            new Product
            {
                Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                Name = "Women's Jeans",
                Description = "Stretch denim, slim fit.",
                Price = 49.99m,
                CategoryId = clothingId
            },
            new Product
            {
                Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                Name = "Ceramic Dinner Set",
                Description = "16-piece porcelain dinnerware set.",
                Price = 79.99m,
                CategoryId = homeId
            },
            new Product
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                Name = "Electric Kettle",
                Description = "1.7L stainless steel kettle with auto shut-off.",
                Price = 29.95m,
                CategoryId = homeId
            },
            new Product
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                Name = "Building Blocks Set",
                Description = "200-piece construction set for ages 6+.",
                Price = 34.99m,
                CategoryId = toysId
            },
            new Product
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                Name = "Remote Control Car",
                Description = "Battery-powered RC car with rechargeable battery.",
                Price = 44.50m,
                CategoryId = toysId
            }
        );
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
