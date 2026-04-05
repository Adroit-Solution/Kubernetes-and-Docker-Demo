using DockerDemo.Database;
using DockerDemo.Dto;
using DockerDemo.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMySQLServer<ApplicationDbContext>(builder.Configuration.GetConnectionString("Mysql") ?? throw new Exception("ConnectionString not present"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Update database on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Product endpoints
app.MapGet("/products", async (ApplicationDbContext db) =>
{
    var products = await db.Products.ToListAsync();
    return Results.Ok(products);
})
.WithName("GetProducts");

app.MapGet("/products/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Console.WriteLine("Product API gets Called");
    var product = await db.Products.FindAsync(id);
    if (product is null) return Results.NotFound();
    return Results.Ok(product);
})
.WithName("GetProductById");

app.MapPost("/products", async (ProductDto dto, ApplicationDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name)) return Results.BadRequest("Name is required.");

    Product entity = (Product)dto;
    db.Add(entity);
    await db.SaveChangesAsync();

    return Results.Created($"/products/{entity.Id}", entity);
})
.WithName("CreateProduct");

app.MapPut("/products/{id:int}", async (int id, ProductDto dto, ApplicationDbContext db) =>
{
    var product = await db.Products.FindAsync(id);

    if (product is null)
        return Results.NotFound();
    product = (Product)dto;
    var dbSet = db.Products.Update(product);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateProduct");

app.MapDelete("/products/{id:int}", async (int id, ApplicationDbContext db) =>
{
    var entity = await db.Products.FindAsync(id);
    if (entity == null) return Results.NotFound();

    db.Remove(entity);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("DeleteProduct");

// Category endpoints

app.MapGet("/categories", async (ApplicationDbContext db) =>
{
    var categories = await db.Categories.ToListAsync();
    return Results.Ok(categories);
})
.WithName("GetCategories");

app.MapGet("/categories/{id:int}", async (int id, ApplicationDbContext db) =>
{
    var category = await db.Categories.FindAsync(id);
    if (category is null) return Results.NotFound();
    return Results.Ok(category);
})
.WithName("GetCategoryById");

app.MapPost("/categories", async (CategoryDto dto, ApplicationDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name)) return Results.BadRequest("Name is required.");

    Category entity = (Category)dto;
    db.Add(entity);
    await db.SaveChangesAsync();

    return Results.Created($"/categories/{entity.Id}", entity);
})
.WithName("CreateCategory");

app.MapPut("/categories/{id:int}", async (int id, CategoryDto dto, ApplicationDbContext db) =>
{
    var category = await db.Categories.FindAsync(id);

    if (category is null)
        return Results.NotFound();
    category = (Category)dto;
    db.Categories.Update(category);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateCategory");

app.MapDelete("/categories/{id:int}", async (int id, ApplicationDbContext db) =>
{
    var entity = await db.Categories.FindAsync(id);
    if (entity == null) return Results.NotFound();

    db.Remove(entity);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("DeleteCategory");

app.Run();
