using System;
using YaqeenServices.DTOs;
using YaqeenServices.Services;

namespace YaqeenApi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : BaseYaqeenController
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserServices _userServices;
    public UserController(ILogger<UserController> logger, IUserServices userServices)
    {
        _logger = logger;
        _userServices = userServices;
    }

    [HttpGet]
    public IActionResult Index() => Ok("Some data");

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDto userCreateDto) => GetResponse(await _userServices.CreateUser(userCreateDto, "To be implemented"));
}
