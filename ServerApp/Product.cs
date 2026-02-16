using System.Text.Json;

namespace ServerApp;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Stock { get; set; }
    public Category Category { get; set; } = new();
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public static class ProductRepository
{
    private static readonly string FilePath = "products.json";

    public static List<Product> GetAll()
    {
        if (!File.Exists(FilePath))
            return new List<Product>();
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
    }

    public static void SaveAll(List<Product> products)
    {
        var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}
