#pragma checksum "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d1c30dd6e91fb7362f2127f32afaba04e3209b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Panda.App.Views.Package.Views_Package_Shipped), @"mvc.1.0.view", @"/Views/Package/Shipped.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Package/Shipped.cshtml", typeof(Panda.App.Views.Package.Views_Package_Shipped))]
namespace Panda.App.Views.Package
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d1c30dd6e91fb7362f2127f32afaba04e3209b5", @"/Views/Package/Shipped.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0208d359f79d1be24826bf85f404bf536289c55d", @"/Views/_ViewImports.cshtml")]
    public class Views_Package_Shipped : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Panda.App.Models.Package.PackageShippedViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(63, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
  
    ViewData["Title"] = "Shipped";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(155, 905, true);
            WriteLiteral(@"
<h1 class=""text-center"">Pending Shipment</h1>
<hr class=""hr-2 bg-panda"">
<div class=""d-flex justify-content-between"">
    <table class=""table table-hover table-bordered"">
        <thead>
            <tr class=""row"">
                <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>#</h3></th>
                <th scope=""col"" class=""col-lg-4 d-flex justify-content-center""><h3>Description</h3></th>
                <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Weight</h3></th>
                <th scope=""col"" class=""col-lg-3 d-flex justify-content-center""><h3>Estimated Delivery Date</h3></th>
                <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Recipient</h3></th>
                <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Actions</h3></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 23 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
             for (int i = 0; i < Model.Count(); i++)
            {

#line default
#line hidden
            BeginContext(1129, 121, true);
            WriteLiteral("                <tr class=\"row\">\r\n                    <th scope=\"row\" class=\"col-lg-1 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1252, 3, false);
#line 26 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
                                                                                   Write(i+1);

#line default
#line hidden
            EndContext();
            BeginContext(1256, 87, true);
            WriteLiteral("</h5></th>\r\n                    <td class=\"col-lg-4 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1344, 20, false);
#line 27 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
                                                                      Write(Model[i].Description);

#line default
#line hidden
            EndContext();
            BeginContext(1364, 87, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-1 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1452, 32, false);
#line 28 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
                                                                      Write(Model[i].Weight.ToString("0.00"));

#line default
#line hidden
            EndContext();
            BeginContext(1484, 87, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-3 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1572, 30, false);
#line 29 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
                                                                      Write(Model[i].EstimatedDeliveryDate);

#line default
#line hidden
            EndContext();
            BeginContext(1602, 87, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-2 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1690, 18, false);
#line 30 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
                                                                      Write(Model[i].Recipient);

#line default
#line hidden
            EndContext();
            BeginContext(1708, 111, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-1 d-flex justify-content-center\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1819, "\"", 1855, 2);
            WriteAttributeValue("", 1826, "/Package/Deliver/", 1826, 17, true);
#line 32 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
WriteAttributeValue("", 1843, Model[i].Id, 1843, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1856, 96, true);
            WriteLiteral(" class=\"btn bg-panda text-white\">Deliver</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 35 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Shipped.cshtml"
            }

#line default
#line hidden
            BeginContext(1967, 40, true);
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Panda.App.Models.Package.PackageShippedViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
