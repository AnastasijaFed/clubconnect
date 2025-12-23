using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class Club
{
    public int Id { get; set; }
    public string Name { get; set; } 
    [Required]
    public string Category {get; set;} 

    [Required]
    public string Address {get; set;} 
    [Required]
    public string City {get; set;}

    [Required]
    public string? Phone { get; set; }
    [Required]
    public string? Email { get; set; }


    public string? LogoUrl { get; set; }

    public string? CoverImageUrl { get; set; }

    public bool IsActive { get; set; }
     public bool IsDeleted { get; set; }
    public bool IsVerified { get; set; } 

    [Required]
    public int OwnerUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
