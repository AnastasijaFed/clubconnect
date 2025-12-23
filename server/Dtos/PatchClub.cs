namespace server.Dtos;

public record PatchClub
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? LogoUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public bool? IsActive { get; set; }
}