using YaqeenServices;

namespace YaqeenApi.Controllers;

[ApiController]
public abstract class BaseYaqeenController : ControllerBase
{
    public IActionResult GetResponse<T>(SingleResult<T> result)
    {
        return (result.Success) ?
            Ok(result) :
            result.IsValidationError ?
                BadRequest(result) :
                StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessages);
    }
}
