#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c0dd1f30cf956853f5dfb08da4603c3f667defd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Comunes_Views_Roles_Index), @"mvc.1.0.view", @"/Areas/Comunes/Views/Roles/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c0dd1f30cf956853f5dfb08da4603c3f667defd", @"/Areas/Comunes/Views/Roles/Index.cshtml")]
    public class Areas_Comunes_Views_Roles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SISST.ViewModels.Comunes.Roles.VMRol>>
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
#line 2 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
   ViewData["Title"] = "Roles de usuario";
    Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card card-default \">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n            <div class=\"col-8\">\r\n                <h3 class=\"pl-3\">");
#nullable restore
#line 9 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                <ol class=""breadcrumb mb-0 "" style=""background-color:white;"">
                    <li class=""breadcrumb-item active"">
                        Lista de roles
                    </li>
                </ol>
            </div>
            <div class=""col-4 text-right mt-3"">
                ");
#nullable restore
#line 17 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
           Write(Html.ActionLink("Nuevo rol", "Create", "Roles", new { Area = "Comunes" }, new { @class = "btn btn_sistema" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<div class=""card card-default "">
    <h4 class=""card-header"">
        Lista de roles
    </h4>
    <div class=""card-body"">
        <table class=""table table-striped my-4 w-100 border-gray border dataTables-example"">
            <thead>
                <tr>
                    <th>
                        Rol
                    </th>
                    <th>
                        ");
#nullable restore
#line 35 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                   Write(Html.DisplayName("Descripci??n"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 38 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                   Write(Html.DisplayName("Prioridad"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 41 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                   Write(Html.DisplayName("Estatus"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 46 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1708, "\"", 1787, 1);
#nullable restore
#line 50 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
WriteAttributeValue("", 1715, Url.Action("Details", "Roles", new { Area = "Comunes", id= @item.id } ), 1715, 72, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 50 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                                                                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 53 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 56 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.prioridad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 59 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                             if (item.activo)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                           Write(Html.Label("Activo"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                                                     
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                           Write(Html.Label("Inactivo"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                                                       
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 69 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3c0dd1f30cf956853f5dfb08da4603c3f667defd10205", async() => {
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
                WriteLiteral("\r\n    ");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c0dd1f30cf956853f5dfb08da4603c3f667defd11552", async() => {
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
                WriteLiteral("\r\n\r\n            <script>\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 85 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr.options.positionClass = \'toast-bottom-right\';\r\n                toastr[\'");
#nullable restore
#line 87 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                   Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 87 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Roles\Index.cshtml"
                                               Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                }\r\n            });\r\n            </script>\r\n    ");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SISST.ViewModels.Comunes.Roles.VMRol>> Html { get; private set; }
    }
}
#pragma warning restore 1591
