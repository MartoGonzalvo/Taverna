using ControlPortales.Api.Exceptions;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;

namespace ControlPortales.Api.Helpers
{
    public static class ProblemDetailsConfiguration
    {
        public static void ConfigureProblemDetailsOptions(ProblemDetailsOptions options)
        {
            // Only include exception details in a development environment. There's really no nee
            // to set this as it's the default behavior. It's just included here for completeness 🙂
            options.IncludeExceptionDetails = (ctx, env) => false;


            options.Map<RequestException>(exception => new ProblemDetails
            {
                Title = exception.Title,
                Detail = exception.Detail,
                Status = exception.Status,
                Type = exception.Type
            });

            options.Map<Exception>(exception => new ProblemDetails
            {
                Title = "",
                Detail = exception.Message,
                Status = StatusCodes.Status400BadRequest,
                Type = ""
            });

            // You can configure the middleware to re-throw certain types of exceptions, all exceptions or based on a predicate.
            // This is useful if you have upstream middleware that needs to do additional handling of exceptions.
            options.Rethrow<NotSupportedException>();

            // This will map HttpRequestException to the 503 Service Unavailable status code.
            options.MapToStatusCode<HttpRequestException>(StatusCodes.Status503ServiceUnavailable);

            // Because exceptions are handled polymorphically, this will act as a "catch all" mapping, which is why it's added last.
            // If an exception other than NotImplementedException and HttpRequestException is thrown, this will handle it.
            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
        }
    }
}