namespace API;

using Application.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public abstract class DefaultController : ControllerBase
{
    protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>() ?? throw new Exception("Mediator Null");

    protected IActionResult Send<T>(DefaultResponse<T> resp) where T : class
    {
        return StatusCode(resp.StatusCode, resp);
    }
}
