namespace Kalbepedia.Contracts.Product;

public record UpdateProductRequest(
    int ProductCategoryId,
    string Name,
    string Description,
    int StockQty,
    int Price,
    string ImageUrl);