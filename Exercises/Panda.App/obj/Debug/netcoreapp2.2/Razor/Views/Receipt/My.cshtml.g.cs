#pragma checksum "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5141ad6e14fb3a2ca0661b0ee35a9de1e228922b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Panda.App.Views.Receipt.Views_Receipt_My), @"mvc.1.0.view", @"/Views/Receipt/My.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Receipt/My.cshtml", typeof(Panda.App.Views.Receipt.Views_Receipt_My))]
namespace Panda.App.Views.Receipt
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\asp.net Core MVC\Exercises\Panda.App\Views\_ViewImports.cshtml"
using Panda.App;

#line default
#line hidden
#line 2 "D:\asp.net Core MVC\Exercises\Panda.App\Views\_ViewImports.cshtml"
using Panda.Domain;

#line default
#line hidden
#line 3 "D:\asp.net Core MVC\Exercises\Panda.App\Views\_ViewImports.cshtml"
using Panda.App.Models.Package;

#line default
#line hidden
#line 4 "D:\asp.net Core MVC\Exercises\Panda.App\Views\_ViewImports.cshtml"
using Panda.App.Models.Receipt;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5141ad6e14fb3a2ca0661b0ee35a9de1e228922b", @"/Views/Receipt/My.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0208d359f79d1be24826bf85f404bf536289c55d", @"/Views/_ViewImports.cshtml")]
    public class Views_Receipt_My : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ReceiptMyViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml"
  
    ViewData["Title"] = "My";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(118, 780, true);
            WriteLiteral(@"
<h1 class=""text-center"">My Receipts</h1>
<hr class=""hr-2 bg-panda"">
<div class=""d-flex justify-content-between"">
    <table class=""table table-hover table-bordered"">
        <thead>
            <tr class=""row"">
                <th scope=""col"" class=""col-lg-5 d-flex justify-content-center""><h3>Id</h3></th>
                <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Fee</h3></th>
                <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Issued On</h3></th>
                <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Recipient</h3></th>
                <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Actions</h3></th>
            </tr>
        </thead>
        <tbody>

");
            EndContext();
#line 22 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml"
             foreach (var receipt in Model)
            {

#line default
#line hidden
            BeginContext(958, 121, true);
            WriteLiteral("                <tr class=\"row\">\r\n                    <th scope=\"row\" class=\"col-lg-5 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1080, 10, false);
#line 25 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml"
                                                                                  Write(receipt.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1090, 87, true);
            WriteLiteral("</h5></th>\r\n                    <td class=\"col-lg-2 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1178, 11, false);
#line 26 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml"
                                                                      Write(receipt.Fee);

#line default
#line hidden
            EndContext();
            BeginContext(1189, 87, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-2 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1277, 16, false);
#line 27 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml"
                                                                      Write(receipt.IssuedOn);

#line default
#line hidden
            EndContext();
            BeginContext(1293, 87, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-2 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1381, 17, false);
#line 28 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml"
                                                                      Write(receipt.Recipient);

#line default
#line hidden
            EndContext();
            BeginContext(1398, 111, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-1 d-flex justify-content-center\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1509, "\"", 1543, 2);
            WriteAttributeValue("", 1516, "Receipt/Details/", 1516, 16, true);
#line 30 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml"
WriteAttributeValue("", 1532, receipt.Id, 1532, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1544, 96, true);
            WriteLiteral(" class=\"btn bg-panda text-white\">Details</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 33 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Receipt\My.cshtml"
            }

#line default
#line hidden
            BeginContext(1655, 38, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ReceiptMyViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
