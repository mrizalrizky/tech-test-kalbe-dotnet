public record CreateUserRequest(
    string username,
    string fullName,
    string email,
    string password,
    bool isActive);