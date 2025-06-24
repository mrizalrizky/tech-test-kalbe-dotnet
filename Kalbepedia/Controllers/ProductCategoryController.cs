using Kalbepedia.Contracts.ProductCategory;
using Kalbepedia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Product.Controller.ProductCategoryController;

[ApiController]
[Route("api/v1/product-categories")]
public class ProductCategoryController : ControllerBase
{
        private readonly AppDbContext _context;
    
    public ProductCategoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateProductCategory(CreateProductCategoryRequest request)
    {
        var productCategory = new Kalbepedia.Models.ProductCategory(
                    request.Name);
        Console.WriteLine("productCategory created", productCategory);
        _context.Product_Categories.Add(productCategory);
         await _context.SaveChangesAsync();
        var response = new ProductCategoryResponse(
            productCategory.Id,
            productCategory.Name);

        return Ok(new { status = true, data = response });
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllProductCategories()
    {
        var categories = await _context.Product_Categories.ToListAsync();

        var responses = categories.Select(category => new ProductCategoryResponse(
            category.Id,
            category.Name
        )).ToList();

        return Ok(new { status = true, data = responses });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductCategoryById(int id)
    {
          var category = await _context.Product_Categories.FindAsync(id);
        if (category == null) return NotFound();

        var response = new ProductCategoryResponse(
            category.Id,
            category.Name);

        return Ok(new { status = true, data = response });
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProductCategoryById(int id, UpdateProductCategoryRequest request)
    {
        var category = await _context.Product_Categories.FindAsync(id);
        if (category == null) return NotFound();

        category.Name = request.Name;

        await _context.SaveChangesAsync();

        return Ok(new{ status = true, data = new ProductCategoryResponse(
            category.Id,
            category.Name)});
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProductCategoryById(int id)
    {
        var category = await _context.Product_Categories.FindAsync(id);
        if (category == null) return NotFound();

        _context.Product_Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}