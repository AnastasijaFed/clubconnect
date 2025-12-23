using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using server.Data;
using server.Models;
using server.Dtos;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;
    public UsersController(AppDbContext db) => _db = db;

    private static UserDto ToDto(User user)
{
    return new UserDto
    {
        Id = user.Id,
        Email = user.Email,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Phone = user.Phone,
        AvatarUrl = user.AvatarUrl,
        Role = user.Role
    };
}


    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> Get([FromQuery] string? firstName, [FromQuery] string? lastName, [FromQuery] string? role)
    {
        var query = _db.Users.Where(u => !u.IsDeleted).AsQueryable();


        if(!string.IsNullOrWhiteSpace(firstName)) {
            query = query.Where(user => EF.Functions.ILike(user.FirstName, firstName.Trim()));

        }
        if (!string.IsNullOrWhiteSpace(lastName))
        {
             query = query.Where(user => EF.Functions.ILike(user.LastName, lastName.Trim()));

        }
         if (!string.IsNullOrWhiteSpace(role))
        {
             query = query.Where(user => EF.Functions.ILike(user.Role, role.Trim()));

        }

        var users = await query.ToListAsync();
        return Ok(users.Select(ToDto).ToList());

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
    {
        var user = await _db.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
        if(user == null || user.IsDeleted) return NotFound();
        return Ok(ToDto(user));
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof (GetById), new {id = user.Id}, ToDto(user));
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<User>> Patch([FromRoute] int id, [FromBody] PatchUser patch)
    {
        var user = await _db.Users.FindAsync(id);
        if(user == null) return NotFound();

        if(patch.Email != null) user.Email = patch.Email;
        if(patch.FirstName != null) user.FirstName = patch.FirstName;
        if(patch.LastName != null) user.LastName = patch.LastName;
        if(patch.Phone != null) user.Phone = patch.Phone;
        if(patch.AvatarUrl != null) user.AvatarUrl = patch.AvatarUrl;
        
        await _db.SaveChangesAsync();
        return Ok(ToDto(user));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var user = await _db.Users.FindAsync(id);
        if(user == null) return NotFound();

        user.IsDeleted = true;

        await _db.SaveChangesAsync();
        return NoContent();


    }




}