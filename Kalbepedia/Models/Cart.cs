using System.ComponentModel.DataAnnotations;

namespace Kalbepedia.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }
    
    public Cart() { }
    public Cart(int userId, int productId)
    {
        UserId = userId;
        ProductId = productId;
    }
}