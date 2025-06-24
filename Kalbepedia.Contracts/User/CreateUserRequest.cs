public record CreateUserRequest(
    string Username,
    string FullName,
    string Email,
    string Password);