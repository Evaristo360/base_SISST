#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Home\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed5dd2e70516aebe8f3bc6c55950ce5ec5b2505b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Error), @"mvc.1.0.view", @"/Views/Home/Error.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\_ViewImports.cshtml"
using SISST;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\_ViewImports.cshtml"
using SISST.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed5dd2e70516aebe8f3bc6c55950ce5ec5b2505b", @"/Views/Home/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c56b15d81227fa3fe2d997657fb56d023b35578", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Home\Error.cshtml"
  
    ViewData["Title"] = "Se ha detectado un error";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Home\Error.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p>Ha ocurrido un error. ");
#nullable restore
#line 6 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Home\Error.cshtml"
                    Write(ViewBag.mensaje);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591