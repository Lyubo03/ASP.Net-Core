namespace RazorLection.TagHelpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using RazorLection.Services;

    [HtmlTargetElement("h1", Attributes =  "greeting-name")]
    public class HelloTagHelper : TagHelper
    {
        private readonly IUserService service;
        public HelloTagHelper(IUserService service)
        {
            this.service = service;
        }

        public string GreetingName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("name", this.GreetingName);
            output.Content.SetContent("set Sth");
        } 
    }
}