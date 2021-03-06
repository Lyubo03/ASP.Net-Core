#pragma checksum "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc483dd4f83c863fe23e94de3bac56ed58e9a8c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Panda.App.Views.Package.Views_Package_Delivered), @"mvc.1.0.view", @"/Views/Package/Delivered.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Package/Delivered.cshtml", typeof(Panda.App.Views.Package.Views_Package_Delivered))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc483dd4f83c863fe23e94de3bac56ed58e9a8c0", @"/Views/Package/Delivered.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0208d359f79d1be24826bf85f404bf536289c55d", @"/Views/_ViewImports.cshtml")]
    public class Views_Package_Delivered : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Panda.App.Models.Package.PackageDeliveredViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(65, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
  
    ViewData["Title"] = "Delivered";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(159, 891, true);
            WriteLiteral(@"
<h1 class=""text-center"">Delivered</h1>
<hr class=""hr-2 bg-panda"">
<div class=""d-flex justify-content-between"">
    <table class=""table table-hover table-bordered"">
        <thead>
            <tr class=""row"">
                <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>#</h3></th>
                <th scope=""col"" class=""col-lg-4 d-flex justify-content-center""><h3>Description</h3></th>
                <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Weight</h3></th>
                <th scope=""col"" class=""col-lg-3 d-flex justify-content-center""><h3>Shipping Address</h3></th>
                <th scope=""col"" class=""col-lg-2 d-flex justify-content-center""><h3>Recipient</h3></th>
                <th scope=""col"" class=""col-lg-1 d-flex justify-content-center""><h3>Actions</h3></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 23 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
             for (int i = 0; i < Model.Count(); i++)
            {

#line default
#line hidden
            BeginContext(1119, 121, true);
            WriteLiteral("                <tr class=\"row\">\r\n                    <th scope=\"row\" class=\"col-lg-1 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1242, 3, false);
#line 26 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
                                                                                   Write(i+1);

#line default
#line hidden
            EndContext();
            BeginContext(1246, 87, true);
            WriteLiteral("</h5></th>\r\n                    <td class=\"col-lg-4 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1334, 20, false);
#line 27 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
                                                                      Write(Model[i].Description);

#line default
#line hidden
            EndContext();
            BeginContext(1354, 87, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-1 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1442, 32, false);
#line 28 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
                                                                      Write(Model[i].Weight.ToString("0.00"));

#line default
#line hidden
            EndContext();
            BeginContext(1474, 87, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-3 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1562, 24, false);
#line 29 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
                                                                      Write(Model[i].ShippingAddress);

#line default
#line hidden
            EndContext();
            BeginContext(1586, 87, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-2 d-flex justify-content-center\"><h5>");
            EndContext();
            BeginContext(1674, 18, false);
#line 30 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
                                                                      Write(Model[i].Recipient);

#line default
#line hidden
            EndContext();
            BeginContext(1692, 111, true);
            WriteLiteral("</h5></td>\r\n                    <td class=\"col-lg-1 d-flex justify-content-center\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1803, "\"", 1839, 2);
            WriteAttributeValue("", 1810, "/Package/Details/", 1810, 17, true);
#line 32 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
WriteAttributeValue("", 1827, Model[i].Id, 1827, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1840, 96, true);
            WriteLiteral(" class=\"btn bg-panda text-white\">Details</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 35 "D:\asp.net Core MVC\Exercises\Panda.App\Views\Package\Delivered.cshtml"
            }

#line default
#line hidden
            BeginContext(1951, 38, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Panda.App.Models.Package.PackageDeliveredViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
