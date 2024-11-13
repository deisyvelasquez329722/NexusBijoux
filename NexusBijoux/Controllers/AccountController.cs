using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NexusBijoux.Components.Models;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(); // Devolver 200 OK para la llamada AJAX
            }
            return BadRequest("Invalid login attempt.");
        }
        return BadRequest(ModelState);
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
    
    [HttpGet("IsAdmin")]
    public async Task<IActionResult> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        return Ok(isAdmin);
    }
    
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                UserName = model.alias,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }
            return BadRequest(result.Errors);
        }
        return BadRequest(ModelState);
    }
}