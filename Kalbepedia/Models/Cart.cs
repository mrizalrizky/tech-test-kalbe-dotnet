using System.ComponentModel.DataAnnotations;

namespace Kalbepedia.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }
    
    public Cart() { }
    public Cart(int id, int userId, int productId)
    {
        Id = id;
        UserId = userId;
        ProductId = productId;
    }
}