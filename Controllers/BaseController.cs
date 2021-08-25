using TrucknDriver.Utilities.ApiResponse;
using Microsoft.AspNetCore.Mvc;


namespace TrucknDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult FromExecutionResult(ExecutionResult result)
        {
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Errors);
        }

        protected IActionResult FromExecutionResult<T>(ExecutionResult<T> result, object value = null)
        {
            if (result.Success)
                return Ok(value ?? result);
            return BadRequest(result.Errors);
        }
    }
}
