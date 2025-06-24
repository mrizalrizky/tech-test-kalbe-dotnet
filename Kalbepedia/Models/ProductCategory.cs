using System.ComponentModel.DataAnnotations;

namespace Kalbepedia.Models;

public class ProductCategory
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public ProductCategory() { }
    public ProductCategory(string name)
    {
        Name = name;
    }
}