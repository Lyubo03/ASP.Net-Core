namespace Filter.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;

    public class ValidateModelStateFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ContentResult() { Content = "Invalid model state" };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
             
        }
    }
}