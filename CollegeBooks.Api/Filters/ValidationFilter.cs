using CollegeBooks.Logic;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CollegeBooks.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var paramObject = context.ActionArguments.SingleOrDefault(x => x.Value is IValidable).Value;

            if (paramObject != null)
            {
                IValidable paramDto = (IValidable)paramObject;

                var errors = await paramDto.Validate();

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    context.Result = new BadRequestObjectResult(errors);
                    return;
                }
            }
            await next();
        }
    }
}
