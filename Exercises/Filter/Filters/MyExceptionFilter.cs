namespace Filter.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
        }
    }
}