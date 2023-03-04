using GameOfFoodies.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace PasswordRecovery.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        // Register logic here

        return Ok(request);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        // Login logic here

        return Ok(request);
    }
}

