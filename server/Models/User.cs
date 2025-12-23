using System.Runtime.CompilerServices;

public class User
{
    public int Id {get; set;}
    public string Email {get; set;}
    public string PasswordHash {get; set;}
    public string Role {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Phone {get; set;}
    public string? AvatarUrl {get; set;}
    public bool IsActive{get; set;}
    public bool IsDeleted{get; set;}
    public bool IsEmailVerified {get; set;}

    public DateTime CreatedAt{get; set;}
    public DateTime LastLoginAt {get; set;}


}