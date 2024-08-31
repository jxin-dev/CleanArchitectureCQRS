
using CleanArchitectureCQRS.SharedKernel.Models;
using Newtonsoft.Json;

namespace CleanArchitectureCQRS.API.Utilities
{
    public class CustomProblemResult : IResult
    {
        public Error Error { get; }
        public CustomProblemResult(Error error)
        {
            Error = error;
        }
        public async Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = Error.StatusCode;

            var response = JsonConvert.SerializeObject(new { code = Error.Code, description = Error.Description });
            await httpContext.Response.WriteAsync(response);
        }
    }
}
