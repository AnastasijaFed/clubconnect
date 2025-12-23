using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Dtos;

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
    public async Task<IActionResult> Update(int id, UpdateClub dto)
    {
        var club = await _db.Clubs.FindAsync(id);
        if (club == null) return NotFound();

        club.Name = dto.Name;
        club.Category = dto.Category;
        club.Address = dto.Address;
        club.City = dto.City;
        club.Phone = dto.Phone;
        club.Email = dto.Email;
        club.LogoUrl = dto.LogoUrl;
        club.CoverImageUrl = dto.CoverImageUrl;
        club.IsActive = dto.IsActive;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Club>> Patch([FromRoute] int id, [FromBody] PatchClub patch)
    {
    var club = await _db.Clubs.FindAsync(id);
    if (club == null) return NotFound();

    if (patch.Name != null) club.Name = patch.Name;
    if (patch.Category != null) club.Category = patch.Category;
    if (patch.Address != null) club.Address = patch.Address;
    if (patch.City != null) club.City = patch.City;
    if (patch.Phone != null) club.Phone = patch.Phone;
    if (patch.Email != null) club.Email = patch.Email;
    if (patch.LogoUrl != null) club.LogoUrl = patch.LogoUrl;
    if (patch.CoverImageUrl != null) club.CoverImageUrl = patch.CoverImageUrl;
    if (patch.IsActive.HasValue) club.IsActive = patch.IsActive.Value;

    await _db.SaveChangesAsync();
    return Ok(club);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var club = await _db.Clubs.FindAsync(id);
        if(club == null) return NotFound();

        club.IsDeleted = true;

        await _db.SaveChangesAsync();
        return NoContent();
    }
    
        
    }
    
