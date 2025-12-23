namespace server.Dtos;

public record PatchUser
{
    public string? Email;
    public string? FirstName;
    public string? LastName;
    public string? Phone;
    public string? AvatarUrl;
}