using API.ViewModels;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Services;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(UserManager<User> userManager, TokenService tokenService, IMapper mapper) : ControllerBase
{
    [HttpPost("register")] // account/register
    public async Task<ActionResult<UserVM>> Register(RegisterVM registerVM)
    {
        if (await UserExists(registerVM.Username)) return BadRequest("Username is taken");

        var user = mapper.Map<User>(registerVM);

        user.UserName = registerVM.Username.ToLower();

        var result = await userManager.CreateAsync(user, registerVM.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        return new UserVM
        {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user),
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserVM>> Login(LoginVM loginVM)
    {
        var user = await userManager.Users
                .FirstOrDefaultAsync(x =>
                    x.NormalizedUserName == loginVM.Username.ToUpper());

        if (user == null || user.UserName == null) return Unauthorized("Invalid username");

        return new UserVM
        {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user),
        };
    }

    private async Task<bool> UserExists(string username)
    {
        return await userManager.Users.AnyAsync(x => x.NormalizedUserName == username.ToUpper()); // Bob != bob
    }
}