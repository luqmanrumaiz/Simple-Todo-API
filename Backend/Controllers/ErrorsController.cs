using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class ErrorsController : ControllerBase
{
    // This attribute will make sure that this route is not visible in the Swagger UI as it does not have a purpose
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}