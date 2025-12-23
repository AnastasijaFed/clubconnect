namespace server.Dtos;

public record AuthResponse
(
    string AccessToken,
    int UserId,
    string Email,
    string Role,
    string FirstName,
    string LastName

);
    
