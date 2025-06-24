
namespace Kalbepedia.Contracts.User;
public record UpdateUserRequest(
    string Name,
    string Description,
    int Price,
    string Category,
    string ImageUrl);