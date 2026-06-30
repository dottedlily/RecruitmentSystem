using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using RecruitmentSystem.Models;


[Route("api/[controller]")]
[ApiController]


public class UsersController : ControllerBase
{
    private readonly DatabaseContext _context;

    public UsersController(DatabaseContext context)
    {
        _context = context;
    }


    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUser()
    {
        var result = await _context.Users.Select(x => new Users
        {
            id = x.id,
            email = x.email,
            username = x.username
        }).ToListAsync();

        return Ok(result);
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] Users user)
    {
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    
    }


}

