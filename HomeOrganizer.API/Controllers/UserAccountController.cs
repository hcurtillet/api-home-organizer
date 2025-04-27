using HomeOrganizer.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeOrganizer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserAccountController: Controller
{
    private readonly IIdentityService _identityService;

    public UserAccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet("me")]
    public IActionResult GetUserAccount()
    {
        var user = _identityService.GetCurrentUser();
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);
    }
}