using Kalbepedia.Models;
using Microsoft.AspNetCore.Mvc;
using Kalbepedia.Data;
using Microsoft.EntityFrameworkCore;

namespace Product.Controller.CartController;

[ApiController]
[Route("api/v1/carts")]
public class CartController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public CartController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost()]
    public async  Task<IActionResult> AddToCart(CreateCartRequest request)
    {
        var cart = new Kalbepedia.Models.Cart(
            request.UserId,
            request.ProductId);
        Console.WriteLine("Cart created", cart);
        _context.Carts.Add(cart);
         await _context.SaveChangesAsync();
        var response = new CartResponse(
            cart.Id,
            cart.UserId,
            cart.ProductId);
        return Ok(new { status = true, data = response });
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetCartByUserId(int userId)
    {
        var cart = await _context.Carts.FindAsync(userId);
        if (cart == null) return NotFound();

        var response = new CartResponse(
            cart.Id,
            cart.ProductId,
            cart.UserId);

        return Ok(new {status = true, data = response});
    }

    [HttpDelete("{userId:int}")]
    public async Task<IActionResult> RemoveFromCart(int userId)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null) return NotFound();
        _context.Carts.Remove(cart);

        await _context.SaveChangesAsync();
        return NoContent();
    }
}