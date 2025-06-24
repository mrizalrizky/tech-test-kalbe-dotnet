using System.ComponentModel.DataAnnotations;

namespace Kalbepedia.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public int ProductCategoryId { get; }
    public string Name { get; }
    public string Description { get; }
    public int Price { get; }

    public int StockQty { get; }
    public string ImageUrl { get; }

    public Product() { }
    public Product(int productCategoryId, string name, string description, int price, int stockQty, string imageUrl)
    {
        ProductCategoryId = productCategoryId;
        Name = name;
        Description = description;
        Price = price;
        StockQty = stockQty;
        ImageUrl = imageUrl;
    }
}