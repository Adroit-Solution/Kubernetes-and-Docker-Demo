using DockerDemo.Database;
using DockerDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo.Services;

public class CategoryService
{
    private readonly ApplicationDbContext _db;

    public CategoryService(ApplicationDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _db.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty) return null;
        return await _db.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(Category category)
    {
        if (category is null) throw new ArgumentNullException(nameof(category));
        if (category.Id.Equals(Guid.Empty)) category.Id = Guid.NewGuid();

        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return category;
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        if (category is null) throw new ArgumentNullException(nameof(category));
        if (category.Id.Equals(Guid.Empty)) return false;

        var existing = await _db.Categories.FindAsync(category.Id);
        if (existing is null) return false;

        // Copy updatable fields. Adjust property names to match your Category model.
        existing.Name = category.Name;
        existing.Description = category.Description;
        // add other fields as needed

        _db.Categories.Update(existing);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        if (id == Guid.Empty) return false;

        var existing = await _db.Categories.FindAsync(id);
        if (existing is null) return false;

        _db.Categories.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}
