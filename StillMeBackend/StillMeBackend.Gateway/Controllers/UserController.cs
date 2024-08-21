using Microsoft.AspNetCore.Mvc;
using StillMeBackend.Gateway.DTO;

namespace StillMeBackend.Gateway.Controllers;

[ApiController]
[Route("user")]
public class UserController: ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public ActionResult<IEnumerable<UserViewDto>> GetUsersByName(string pattern)
    {
        return Ok(_userService.GetUsersByName(pattern));
    }
}