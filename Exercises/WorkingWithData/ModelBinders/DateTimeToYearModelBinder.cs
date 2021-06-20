namespace WorkingWithData.ModelBinders
{
    using System;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Threading.Tasks;

    public class DateTimeToYearModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var httpYear = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (DateTime.TryParse(httpYear.FirstValue, out var dateTime))
            {
                bindingContext.Result = ModelBindingResult.Success(dateTime.Year);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}