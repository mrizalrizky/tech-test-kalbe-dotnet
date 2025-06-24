public record ProductResponse(
    int Id,
    int ProductCategoryId,
    string Name,
    string Description,
    int StockQty,
    int Price,
    string ImageUrl);