using DockerDemo.Dto;

namespace DockerDemo.Models;

public class Product
{
    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Product description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Stock keeping unit or vendor code.
    /// </summary>
    public string? SKU { get; set; }

    /// <summary>
    /// Price amount (use <see cref="Currency"/> for currency code).
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// ISO 4217 currency code, e.g., "USD".
    /// </summary>
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Available stock quantity.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Whether the product is active and available for sale.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// UTC creation timestamp.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// UTC last update timestamp.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Optional URL to a product image.
    /// </summary>
    public string? ImageUrl { get; set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = default!;

    public static implicit operator ProductDto(Product product)
    {
        return new ProductDto(product.Id, product.Name, product.Description, product.Price, product.CategoryId, product.SKU, product.Currency, product.Stock, product.IsActive, product.ImageUrl);
    }

    public static explicit operator Product(ProductDto product)
    {
        return new Product
        {
            Currency = product.Currency,
            CategoryId = product.CategoryId,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            IsActive = product.IsActive,
            Name = product.Name,
            Price = product.Price,
            SKU = product.SKU,
            Stock = product.Stock
        };
    }
}