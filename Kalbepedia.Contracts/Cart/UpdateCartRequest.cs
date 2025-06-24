namespace Kalbepedia.Contracts.User;

public record UpdateCartRequest(
    int userId,
    int productId);