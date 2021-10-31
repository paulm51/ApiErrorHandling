using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace ApiErrorHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("/error")]
        public IActionResult Error() => Problem(); // return Problem Details response

        [HttpGet]
        [Route("/error-local-development")]
        public IActionResult Error([FromServices] IWebHostEnvironment environment)
        {
            if (environment.EnvironmentName.ToLower() != "development")
            {
                throw new InvalidOperationException(
                    "Local development Error Handling should not be invoked from non-development environment.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }
    }
}



