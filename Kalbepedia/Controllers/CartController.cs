using Kalbepedia.Models;
using Kalbepedia.Contracts.Cart;
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
    public async  Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var product = new Kalbepedia.Models.Product(
            0,
            request.ProductCategoryId,
            request.Name,
            request.Description,
            request.Price,
            request.StockQty,
            request.ImageUrl);
        Console.WriteLine("product created", product);
        _context.Products.Add(product);
         await _context.SaveChangesAsync();
        var response = new ProductResponse(
            product.Id,
            product.ProductCategoryId,
            product.Name,
            product.Description,
            product.StockQty,
            product.Price,
            product.ImageUrl);
        return Ok(response);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();

        var responses = products.Select(product => new ProductResponse(
            product.Id,
            product.ProductCategoryId,
            product.Name,
            product.Description,
            product.StockQty,
            product.Price,
            product.ImageUrl
        )).ToList();

        return Ok(responses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        var response = new ProductResponse(
            product.Id,
            product.ProductCategoryId,
            product.Name,
            product.Description,
            product.StockQty,
            product.Price,
            product.ImageUrl);

        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProductById(int id, UpdateProductRequest request)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        // product.ProductCategoryId = request.ProductCategoryId;
        // product.Name = request.Name;
        // product.Description = request.Description;
        // product.Price = request.Price;
        // product.StockQty = request.StockQty;
        // product.ImageUrl = request.ImageUrl;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}