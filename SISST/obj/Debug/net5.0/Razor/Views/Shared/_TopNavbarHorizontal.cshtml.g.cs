#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6826d36db42d650933cce2c8f7c2665b72a734e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TopNavbarHorizontal), @"mvc.1.0.view", @"/Views/Shared/_TopNavbarHorizontal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6826d36db42d650933cce2c8f7c2665b72a734e0", @"/Views/Shared/_TopNavbarHorizontal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c56b15d81227fa3fe2d997657fb56d023b35578", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TopNavbarHorizontal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("navbar-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("search.html"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- START Top Navbar-->\r\n<nav class=\"navbar topnavbar navbar-expand-lg navbar-light\">\r\n    <!-- START navbar header-->\r\n");
            WriteLiteral("    <!-- END navbar header-->\r\n    <!-- START Nav wrapper-->\r\n    <div class=\"navbar-collapse collapse\" id=\"topnavbar\">\r\n        <!-- START Left navbar-->\r\n        <ul class=\"nav navbar-nav mr-auto flex-column flex-lg-row\">\r\n            <li");
            BeginWriteAttribute("class", " class=\"", 960, "\"", 1024, 3);
            WriteAttributeValue("", 968, "nav-item", 968, 8, true);
            WriteAttributeValue(" ", 976, "dropdown", 977, 9, true);
#nullable restore
#line 23 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 985, Html.isActive(controller: "Usuarios"), 986, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <a class=\"nav-link dropdown-toggle dropdown-toggle-nocaret\" href=\"#dashboard\" data-toggle=\"dropdown\">Administraci&oacute;n</a>\r\n                <div class=\"dropdown-menu animated fadeIn\">\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 1255, "\"", 1303, 2);
            WriteAttributeValue("", 1263, "dropdown-item", 1263, 13, true);
#nullable restore
#line 26 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 1276, Html.isActive("Usuarios"), 1277, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1304, "\"", 1369, 1);
#nullable restore
#line 26 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue("", 1311, Url.Action("Index", "Usuarios", new { Area = "Comunes" }), 1311, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><em class=\"fas fa-user mr-3\"></em>Usuarios</a>\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 1441, "\"", 1486, 2);
            WriteAttributeValue("", 1449, "dropdown-item", 1449, 13, true);
#nullable restore
#line 27 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 1462, Html.isActive("Roles"), 1463, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1487, "\"", 1549, 1);
#nullable restore
#line 27 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue("", 1494, Url.Action("Index", "Roles", new { Area = "Comunes" }), 1494, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><em class=\"fas fa-users mr-3\"></em>Roles</a>\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 1619, "\"", 1670, 2);
            WriteAttributeValue("", 1627, "dropdown-item", 1627, 13, true);
#nullable restore
#line 28 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 1640, Html.isActive("Privilegios"), 1641, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1671, "\"", 1739, 1);
#nullable restore
#line 28 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue("", 1678, Url.Action("Index", "Privilegios", new { Area = "Comunes" }), 1678, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><em class=\"far fa-address-book mr-3\"></em>Privilegios</a>\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 1822, "\"", 1871, 2);
            WriteAttributeValue("", 1830, "dropdown-item", 1830, 13, true);
#nullable restore
#line 29 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 1843, Html.isActive("Catalogos"), 1844, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1872, "\"", 1938, 1);
#nullable restore
#line 29 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue("", 1879, Url.Action("Index", "Catalogos", new { Area = "Comunes" }), 1879, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><em class=\"far fa-list-alt mr-3\"></em>Cat&aacute;logo</a>\r\n                </div>\r\n            </li>\r\n            <li");
            BeginWriteAttribute("class", " class=\"", 2057, "\"", 2123, 3);
            WriteAttributeValue("", 2065, "nav-item", 2065, 8, true);
            WriteAttributeValue(" ", 2073, "dropdown", 2074, 9, true);
#nullable restore
#line 32 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 2082, Html.isActive(controller: "Incidentes"), 2083, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <a class=\"nav-link dropdown-toggle dropdown-toggle-nocaret\" href=\"#dashboard\" data-toggle=\"dropdown\">Incidentes</a>\r\n                <div class=\"dropdown-menu animated fadeIn\">\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 2343, "\"", 2391, 2);
            WriteAttributeValue("", 2351, "dropdown-item", 2351, 13, true);
#nullable restore
#line 35 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 2364, Html.isActive("Usuarios"), 2365, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 2392, "\"", 2457, 1);
#nullable restore
#line 35 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue("", 2399, Url.Action("Index", "Usuarios", new { Area = "Comunes" }), 2399, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Incidente con lesi??n</a>\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 2507, "\"", 2552, 2);
            WriteAttributeValue("", 2515, "dropdown-item", 2515, 13, true);
#nullable restore
#line 36 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 2528, Html.isActive("Roles"), 2529, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 2553, "\"", 2615, 1);
#nullable restore
#line 36 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue("", 2560, Url.Action("Index", "Roles", new { Area = "Comunes" }), 2560, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Incidente sin lesi??n</a>\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 2665, "\"", 2716, 2);
            WriteAttributeValue("", 2673, "dropdown-item", 2673, 13, true);
#nullable restore
#line 37 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 2686, Html.isActive("Privilegios"), 2687, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 2717, "\"", 2785, 1);
#nullable restore
#line 37 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue("", 2724, Url.Action("Index", "Privilegios", new { Area = "Comunes" }), 2724, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">m??s</a>\r\n                </div>\r\n            </li>\r\n            <li");
            BeginWriteAttribute("class", " class=\"", 2854, "\"", 2920, 3);
            WriteAttributeValue("", 2862, "nav-item", 2862, 8, true);
            WriteAttributeValue(" ", 2870, "dropdown", 2871, 9, true);
#nullable restore
#line 40 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 2879, Html.isActive(controller: "Incidentes"), 2880, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <a class=\"nav-link dropdown-toggle dropdown-toggle-nocaret\" href=\"#dashboard\" data-toggle=\"dropdown\">Gesti??n</a>\r\n            </li>\r\n            <li");
            BeginWriteAttribute("class", " class=\"", 3088, "\"", 3154, 3);
            WriteAttributeValue("", 3096, "nav-item", 3096, 8, true);
            WriteAttributeValue(" ", 3104, "dropdown", 3105, 9, true);
#nullable restore
#line 43 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue(" ", 3113, Html.isActive(controller: "Incidentes"), 3114, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                <a class=""nav-link dropdown-toggle dropdown-toggle-nocaret"" href=""#dashboard"" data-toggle=""dropdown"">Infraestructura</a>
            </li>
        </ul>
        <!-- END Left navbar-->
        <!-- START Right Navbar-->
        <ul class=""navbar-nav flex-row"">
            <!-- START lock screen-->
            <li class=""nav-item"">
                <a class=""nav-link""");
            BeginWriteAttribute("href", " href=\"", 3550, "\"", 3602, 1);
#nullable restore
#line 52 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontal.cshtml"
WriteAttributeValue("", 3557, Url.Action("Logout", "Home",new {area = ""}), 3557, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" title=""Lock screen"">
                    <em class=""icon-lock""></em>
                </a>
            </li>
            <!-- END lock screen-->
            
            <!-- Fullscreen (only desktops)-->
            <li class=""nav-item d-none d-md-block"">
                <a class=""nav-link"" href=""#"" data-toggle-fullscreen="""">
                    <em class=""fa fa-expand""></em>
                </a>
            </li>
            
            <!-- START Offsidebar button
            <li class=""nav-item"">
                <a class=""nav-link"" href=""#"" data-toggle-state=""offsidebar-open"" data-no-persist=""true"">
                    <em class=""icon-notebook""></em>
                </a>
            </li>
            <!-- END Offsidebar menu-->
        </ul>
        <!-- END Right Navbar-->
    </div>
    <!-- END Nav wrapper-->
    <!-- START Search form-->
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6826d36db42d650933cce2c8f7c2665b72a734e015624", async() => {
                WriteLiteral(@"
        <div class=""form-group"">
            <input class=""form-control"" type=""text"" placeholder=""Type and hit enter ..."">
            <div class=""fa fa-times navbar-form-close"" data-search-dismiss=""""></div>
        </div>
        <button class=""d-none"" type=""submit"">Submit</button>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <!-- END Search form-->\r\n</nav>\r\n<!-- END Top Navbar-->\r\n\r\n");
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
