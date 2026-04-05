using DockerDemo.Dto;

namespace DockerDemo.Models;

public class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Slug { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; } = true;

    // Implicit conversion from Category (model) to CategoryDto
    public static implicit operator CategoryDto(Category category)
    {
        return new CategoryDto(
            category.Id,
            category.Name,
            category.Slug,
            category.Description,
            category.IsActive
        );
    }

    // Explicit conversion from CategoryDto to Category (model)
    public static explicit operator Category(CategoryDto dto)
    {
        return new Category
        {
            Name = dto.Name,
            Slug = dto.Slug,
            Description = dto.Description,
            IsActive = dto.IsActive
        };
    }
}