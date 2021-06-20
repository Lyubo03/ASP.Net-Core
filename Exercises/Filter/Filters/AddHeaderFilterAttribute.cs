using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace Filter.Filters
{
    public class AddHeaderFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string header;
        private readonly string value;

        public AddHeaderFilterAttribute(string header, string value)
        {
            this.header = header;
            this.value = value;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add(this.header, this.value);
            await next();
        }
    }
}