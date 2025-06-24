using Kalbepedia.Models;
using Kalbepedia.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Kalbepedia.Data;
using Microsoft.EntityFrameworkCore;
using Kalbepedia.Contracts.User;

namespace User.Controller.UserController;

[ApiController]
[Route("api/v1/auth")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(CreateUserRequest request)
    {
        var isEmailExist = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);
        if (isEmailExist != null)
        {
            return BadRequest(new { status = false, message = "Email already exists" });
        }

        var isUsernameExist = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);
        if (isUsernameExist != null)
        {
            return BadRequest(new { status = false, message = "Username already exists" });
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new Kalbepedia.Models.User(
                request.FullName,
                request.Username,
                hashedPassword,
                request.Email
                );
        Console.WriteLine("User created", user);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        var response = new UserResponse(
            user.Id,
            user.FullName,
            user.Username,
            user.Email);
        return Ok(new { status = true, data = response });
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(UserLoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null)
        {
            return BadRequest(new { status = false, message = "Invalid username" });
        }

        var isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password );
        if(isValidPassword == false)
        {
            return BadRequest(new { status = false, message = "Invalid password" });
        }

        var response = new UserResponse(
            user.Id,
            user.FullName,
            user.Username,
            user.Email);
        return Ok(new { status = true, data = response });
    }



    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();

        var response = new UserResponse(
            user.Id,
            user.FullName,
            user.Username,
            user.Email);
        return Ok(new { status = true, data = response });
    }
    

}