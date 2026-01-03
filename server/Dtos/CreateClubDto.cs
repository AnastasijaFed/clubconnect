namespace server.Dtos;

public record CreateClubDto
(
    string Name,
    string Category,
    string Address,
    string City,
    string? Phone,
    string? Email

);
     
