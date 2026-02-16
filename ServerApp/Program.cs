using ServerApp;

// Crea el builder para la aplicación web
var builder = WebApplication.CreateBuilder(args);

// Configura CORS para permitir solicitudes desde el cliente Blazor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Agrega soporte para cache en memoria
builder.Services.AddMemoryCache();

// Construye la aplicación
var app = builder.Build();

// Aplica la política de CORS
app.UseCors("AllowBlazorClient");

// Endpoint para eliminar un producto
app.MapDelete("/api/products/{id}", (int id) =>
{
    var products = ProductRepository.GetAll();
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product is null)
        return Results.NotFound();
    products.Remove(product);
    ProductRepository.SaveAll(products);
    return Results.NoContent();
});

// Endpoint para actualizar un producto
app.MapPut("/api/products/{id}", (int id, Product updatedProduct) =>
{
    var products = ProductRepository.GetAll();
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product is null)
        return Results.NotFound();
    product.Name = updatedProduct.Name;
    product.Price = updatedProduct.Price;
    product.Stock = updatedProduct.Stock;
    product.Category = updatedProduct.Category;
    ProductRepository.SaveAll(products);
    return Results.Ok(product);
});

// Endpoint para crear un producto
app.MapPost("/api/products", (Product product) =>
{
    var products = ProductRepository.GetAll();
    // Asignar un nuevo Id
    product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
    products.Add(product);
    ProductRepository.SaveAll(products);
    return Results.Created($"/api/products/{product.Id}", product);
});

// Endpoint para obtener la lista de productos
app.MapGet("/api/products", () =>
{
    return ProductRepository.GetAll();
});

// Inicia la aplicación
app.Run();