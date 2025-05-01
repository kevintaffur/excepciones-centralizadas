using Microsoft.AspNetCore.Mvc;
using ProductosAPI.Utils;

namespace ProductosAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult Success(
            object? content = null,
            string message = "Éxito",
            int statusCode = 200)
        {
            CustomResponse response = new CustomResponse()
            {
                StatusCode = statusCode,
                Message = message,
                Content = content
            };

            return StatusCode(statusCode, response);
        }
    }
}
