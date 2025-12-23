namespace server.Dtos;

public record UpdateClub(
    string Name,
    string Category,
    string Address,
    string City,
    string? Phone,
    string? Email,
    string? LogoUrl,
    string? CoverImageUrl,
    bool IsActive
);
