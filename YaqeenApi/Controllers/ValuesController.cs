namespace YaqeenApi.Controllers;

[Route("api/values")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Index() => Ok("Some data");
}
