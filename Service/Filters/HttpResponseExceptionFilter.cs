using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.ViewModels.Common;
using Microsoft.ApplicationInsights;
using Service.Exceptions;

namespace Service.Filters;

public class HttpResponseExceptionFilter : IActionFilter
{
    private readonly TelemetryClient _telemetryClient;

    public HttpResponseExceptionFilter(TelemetryClient telemetryClient)
    {
        _telemetryClient = telemetryClient;
    }
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var exception = context.Exception;

        if (exception == null) return;

        HandleException(context, exception);
    }

    private void HandleException(ActionExecutedContext context, Exception exception)
    {
        context.HttpContext.Response.ContentType = "application/json";

        var isKnownException = exception is HttpResponseException;

        if (isKnownException)
        {
            var knownException = (HttpResponseException)exception;
            object errorObject = knownException.Value is ErrorResponseViewModel errorResponseViewModel ?
                                     errorResponseViewModel :
                                     new { Error = knownException.Value };
            context.Result = new ObjectResult(errorObject)
            {
                StatusCode = knownException.StatusCode
            };
        }
        else switch (exception)
            {
                case ArgumentException:
                    context.Result = new ObjectResult(new ErrorResponseViewModel(0, exception.Message))
                    {
                        StatusCode = 400
                    };
                    break;
                case KeyNotFoundException:
                    context.Result = new ObjectResult(new ErrorResponseViewModel(0, exception.Message))
                    {
                        StatusCode = 404
                    };
                    break;
                default:
                    _telemetryClient.TrackException(exception);
                    context.Result = new ObjectResult(new ErrorResponseViewModel(0, "Error processing your request, please try again, if the problem persists please contact support."))
                    {
                        StatusCode = 500
                    };
                    break;
            }

        context.ExceptionHandled = true;
    }
}