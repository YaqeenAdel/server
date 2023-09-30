namespace YaqeenApi.Controllers;

[ApiController]
[Route("api/protected")]
[Authorize]
public sealed class ProtectedController : ControllerBase
{
    private readonly ILogger<ProtectedController> _logger;

    public ProtectedController(ILogger<ProtectedController> logger)
    {
        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public IActionResult Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _logger.LogInformation("Current user Id: {userId}", userId);

        return Ok("Everything is working");
    }

}
