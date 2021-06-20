namespace Eventures.App.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class AdminActivityLoggerFilter : IActionFilter
    {
        private readonly ILogger<AdminActivityLoggerFilter> logger;
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}