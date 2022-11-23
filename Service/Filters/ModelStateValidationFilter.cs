using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Service.ViewModels.Common;
using System.Net;

namespace Service.Filters;

public class ModelStateValidationFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        var modelState = context.ModelState;
        if (!modelState.IsValid)
        {
            var errorMessage = modelState.Values.First(v => v.ValidationState == ModelValidationState.Invalid)
                .Errors[0].ErrorMessage;
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ErrorResponseViewModel((int)HttpStatusCode.BadRequest, errorMessage));
            return;
        }

        await base.OnActionExecutionAsync(context, next);
    }
}
