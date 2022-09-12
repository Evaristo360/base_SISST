#pragma checksum "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7e6b8b1819b38659434573c1eb0521cf9785970"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Comunes_Views_Catalogos_Index), @"mvc.1.0.view", @"/Areas/Comunes/Views/Catalogos/Index.cshtml")]
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
#line 2 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7e6b8b1819b38659434573c1eb0521cf9785970", @"/Areas/Comunes/Views/Catalogos/Index.cshtml")]
    public class Areas_Comunes_Views_Catalogos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SISST.ViewModels.Comunes.Catalogos.VMCatalogo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/datatable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
   ViewData["Title"] = "Catálogo";
    Layout = "~/Views/Shared/_Layout.cshtml";
    string claseBotonGuardar = Context.Session.GetString("claseBotonGuardar");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card card-default "">
    <div class=""card-header"">
        <div class=""row"">
            <div class=""col-8"">
                <h3 class=""pl-3"">Catálogos del sistema</h3>
                <ol class=""breadcrumb mb-0 "" style=""background-color:white;"">
                    <li class=""breadcrumb-item active"">
                        Lista de catálogos
                    </li>
                </ol>
            </div>
            <div class=""col-4 text-right mt-3"">
                ");
#nullable restore
#line 20 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
           Write(Html.ActionLink("Nuevo catálogo", "Create", "Catalogos", null, new { @class = "btn btn_sistema" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>
<div class=""card card-default "">
    <h4 class=""card-header"">Lista de catálogos</h4>
    <div class=""card-body"">
        <table class=""table table-striped my-4 w-100 border-gray border dataTables-example"">
            <thead>
                <tr>
                    <th>
                        <span data-toggle=""tooltip"" title=""Presione sobre el nombre de catálogo para ver detalles""> Catálogo</span>
                    </th>
                    <th>Descripción</th>
                    <th>Estado</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 39 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"gradeX\">\r\n                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7e6b8b1819b38659434573c1eb0521cf97859706002", async() => {
#nullable restore
#line 42 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
                                                                              Write(item.Nombre);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1695, "~/Comunes/Catalogos/Details/", 1695, 28, true);
#nullable restore
#line 42 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
AddHtmlAttributeValue("", 1723, item.IdCatalogo, 1723, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 43 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
                       Write(item.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 44 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
                       Write(item.EtiquetaEstado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 46 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d7e6b8b1819b38659434573c1eb0521cf97859708674", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 59 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr.options.positionClass = \'toast-bottom-right\';\r\n                    toastr[\'");
#nullable restore
#line 61 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
                       Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 61 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Catalogos\Index.cshtml"
                                                   Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            }\r\n            });\r\n    </script>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7e6b8b1819b38659434573c1eb0521cf978597011019", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SISST.ViewModels.Comunes.Catalogos.VMCatalogo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
