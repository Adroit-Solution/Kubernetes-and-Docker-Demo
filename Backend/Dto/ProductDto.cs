namespace DockerDemo.Dto;

public record ProductDto(Guid? Id, string Name, string? Description, decimal Price, Guid CategoryId, string? SKU, string Currency, int Stock, bool IsActive, string? ImageUrl);
