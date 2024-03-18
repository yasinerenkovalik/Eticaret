using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eticaret.Infrusturucture.Filter;

public class ValidationFilter:IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        { 
          var error=  context.ModelState
                .Where((x => x.Value.Errors.Any()))
                .ToDictionary(e => e.Key, e => e.Value.Errors
                    .Select(e => e.ErrorMessage))
                .ToArray();
          context.Result = new BadRequestObjectResult(error);
        }

        next();
    }
}