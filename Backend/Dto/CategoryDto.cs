namespace DockerDemo.Dto;

public record CategoryDto(Guid? Id, string Name, string? Slug, string? Description, bool IsActive);