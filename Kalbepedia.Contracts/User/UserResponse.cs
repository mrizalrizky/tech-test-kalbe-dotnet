
namespace Kalbepedia.Contracts.User;
public record UserResponse(
    int Id,
    string FullName,
    string Username,
    string Email);