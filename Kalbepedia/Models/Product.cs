using System.ComponentModel.DataAnnotations;

namespace Kalbepedia.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public int ProductCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public int StockQty { get; set; }
    public string ImageUrl { get; set; }

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