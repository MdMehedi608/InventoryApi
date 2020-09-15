using Microsoft.AspNetCore.Mvc.Filters;

namespace JobRecrutmentApi.Helpers
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }
}
