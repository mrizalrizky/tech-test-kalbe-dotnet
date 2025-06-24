namespace Kalbepedia.Contracts.Product;

public record CreateProductRequest(
    int ProductCategoryId,
    string Name,
    string Description,
    int StockQty,
    int Price,
    string ImageUrl);