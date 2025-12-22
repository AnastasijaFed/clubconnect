using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClubsController : ControllerBase
{
    private readonly AppDbContext _db;
    public ClubsController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<List<Club>>> Get([FromQuery] string? city, [FromQuery] string? category)
    {
        var query = _db.Clubs.AsQueryable();

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(club => EF.Functions.ILike(club.City, city.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(club => EF.Functions.ILike(club.Category, category.Trim()));
        }

        var clubs = await query
        .AsNoTracking()
        .ToListAsync();

        return Ok(clubs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Club>> GetById([FromRoute] int id)
    {
        var club = await _db.Clubs.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
        if (club == null) return NotFound();
        return Ok(club);
    }


    [HttpPost]
    public async Task<IActionResult> Create(Club club)
    {
        _db.Clubs.Add(club);
        await _db.SaveChangesAsync();

        return CreatedAtAction(
        nameof(GetById),        
        new { id = club.Id },
        club
    );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody]Club club, [FromRoute] int id)
    {
        var existingClub = await _db.Clubs.SingleOrDefaultAsync(c => c.Id == id);
        if(existingClub == null) return NotFound();

            existingClub.Name = club.Name;
            existingClub.Category = club.Category;
            existingClub.Address = club.Address;
            existingClub.City = club.City;
            existingClub.Phone = club.Phone;
            existingClub.Email = club.Email;
            existingClub.LogoUrl = club.LogoUrl;
            existingClub.CoverImageUrl = club.CoverImageUrl;
            existingClub.IsActive = club.IsActive;

        await _db.SaveChangesAsync();
        return NoContent();
    }




    
}