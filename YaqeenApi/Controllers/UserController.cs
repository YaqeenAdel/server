using System;
using YaqeenServices.DTOs;
using YaqeenServices.Servcies;

namespace YaqeenApi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
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
    public async Task<IActionResult> Create(UserCreateDto userCreateDto)
    {
        var result = await _userServices.CreateUser(userCreateDto);
        return (result.Success) ? 
            Ok(result) : 
            result.IsValidationError ? 
                BadRequest(result) :
                StatusCode(StatusCodes.Status500InternalServerError, result);
    }
}
