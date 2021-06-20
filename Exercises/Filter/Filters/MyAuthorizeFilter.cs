 namespace Filter.Filters
{
    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Threading.Tasks;
    public class MyAuthorizeFilter : AuthorizeFilter
    {
        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            return base.OnAuthorizationAsync(context);
        }
    }
}