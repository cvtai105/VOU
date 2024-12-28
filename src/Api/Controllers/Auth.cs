using Application.DTOs;
using Application.Interfaces;
using Application.Services.AuthServices;
using Application.Services.BrandServices;
using Application.Services.User;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("{role}/auth")]
public class Auth : Controller
{
    #region vars
    private readonly ILogger<Auth> _logger;
    private readonly CreateUserHandler _createUserHandler;
    private readonly GetUserHandler _getUserHandler;
    private readonly IJwtService _jwtService;
    private readonly IBrandServices _brandServices;
    #endregion

    #region ctor
    public Auth(ILogger<Auth> logger, GetUserHandler getUserHandler, CreateUserHandler createUserHandler, IJwtService jwtService, IBrandServices brandServices)
    {
        _createUserHandler = createUserHandler;
        _getUserHandler = getUserHandler;
        _jwtService = jwtService;
        _logger = logger;
        _brandServices = brandServices;
    }
    #endregion

    [HttpPost("login")]
    public async Task<IActionResult> Login(string role, [FromBody] LoginRecord loginInfo)
    {
        if (string.IsNullOrEmpty(loginInfo.Email) || string.IsNullOrEmpty(loginInfo.Password))
        {
            return BadRequest("Email and Password are required.");
        }

        var user = await _getUserHandler.GetByEmail(loginInfo.Email);

        if (user == null) return Unauthorized(new { Message = "Email was not registered" });

        var passwordHash = loginInfo.Password.Hash();
        if (user.Role != role)
            return Unauthorized(new { Message = "Your Email was registerd as " + user.Role });
        if (passwordHash != user.Hash)
            return Unauthorized(new { Message = "Wrong password" });

        var accessToken = _jwtService.GenerateAccessToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken(user);

        return Ok(new
        {
            AccessToken = accessToken,
            TokenType = "Bearer",
            RefreshToken = refreshToken,
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string role, [FromBody] UserRegistration info)
    {
        if (string.IsNullOrEmpty(info.Email) || string.IsNullOrEmpty(info.FullName) || string.IsNullOrEmpty(info.Password) || string.IsNullOrEmpty(info.Phone))
        {
            return BadRequest("Email, Password, FullName, and Phone are required.");
        }

        var user = await _getUserHandler.GetByEmail(info.Email);
        if (user != null)
        {
            return BadRequest("Email is already registered.");
        }

        var createUserParam = info.ToCreateUserParam(role);
        var newUser = await _createUserHandler.ExecuteAsync(createUserParam);

        // If role is brand, create a brand
        if (role == "brand")
        {
            var brand = new Brand()
            {
                Id = Guid.NewGuid(),
                UserId = newUser.Id,
            };
            await _brandServices.CreateBrandAsync(brand);
        }

        var accessToken = _jwtService.GenerateAccessToken(newUser);
        var refreshToken = _jwtService.GenerateRefreshToken(newUser);

        return Ok(new
        {
            AccessToken = accessToken,
            TokenType = "Bearer",
            RefreshToken = refreshToken,
        });
    }
}