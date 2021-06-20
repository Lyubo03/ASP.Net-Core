namespace Middleware.Middlewears
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class AddInfoHeaderMiddleware
    {
        private readonly RequestDelegate next;

        public AddInfoHeaderMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.Add("X-Length", context.Response.ContentLength.ToString());
            await this.next(context);
        }
    }
}