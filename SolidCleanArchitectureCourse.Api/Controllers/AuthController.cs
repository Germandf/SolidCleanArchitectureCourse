using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidCleanArchitectureCourse.Application.Contracts.Identity;
using SolidCleanArchitectureCourse.Application.Models.Identity;

namespace SolidCleanArchitectureCourse.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authService.Login(request));
    }

    [HttpPost("Register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        return Ok(await _authService.Register(request));
    }
}
