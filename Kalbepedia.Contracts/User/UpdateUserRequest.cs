namespace Kalbepedia.Contracts.User;

public record UpdateUserRequest(
    string username,
    string fullName,
    string email,
    string password,
    bool isActive);