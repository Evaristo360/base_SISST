#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "deca9ed516f032505cc42e568de89254a787cda2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Comunes_Views_Configuracion_Details), @"mvc.1.0.view", @"/Areas/Comunes/Views/Configuracion/Details.cshtml")]
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
#line 2 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deca9ed516f032505cc42e568de89254a787cda2", @"/Areas/Comunes/Views/Configuracion/Details.cshtml")]
    public class Areas_Comunes_Views_Configuracion_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SISST.ViewModels.Comunes.Catalogos.VMConfiguracion>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Comunes/Configuracion/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
   ViewData["Title"] = "Consulta de configuraci??n";
    Layout = "~/Views/Shared/_Layout.cshtml";
    string claseBotonGuardar = Context.Session.GetString("claseBotonGuardar");
    string claseBotonCancelar = Context.Session.GetString("claseBotonCancelar");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card card-default\">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n            <div class=\"col-8\">\r\n                <h3 class=\"pl-3\">Configuraci??n ");
#nullable restore
#line 14 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
                                          Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <ol class=\"breadcrumb mb-0 \" style=\"background-color:white;\">\r\n                    <li class=\"breadcrumb-item\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "deca9ed516f032505cc42e568de89254a787cda24340", async() => {
                WriteLiteral("Lista de configuraciones");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </li>\r\n                    <li class=\"breadcrumb-item active\">Consulta de configuraci??n</li>\r\n                </ol>\r\n            </div>\r\n            <div class=\"col-4 text-right mt-3\">\r\n                ");
#nullable restore
#line 23 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
           Write(Html.ActionLink("Lista de configuraciones", "Index", "Configuracion", null, new { @class = "btn btn_sistema" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"card card-default\">\r\n    <h4 class=\"card-header\">Consulta de configuraci??n</h4>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 32 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
         using (Html.BeginForm())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
       Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 37 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
           Write(Html.LabelFor(model => model.Nombre, htmlAttributes: new { @class = "col-md-2  pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    <input class=\"form-control\" type=\"text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 1735, "\"", 1749, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1750, "\"", 1771, 1);
#nullable restore
#line 39 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
WriteAttributeValue("", 1758, Model.Nombre, 1758, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly=\"readonly\" />\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 43 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
           Write(Html.LabelFor(model => model.Variable, htmlAttributes: new { @class = "col-md-2  pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    <textarea class=\"form-control\" type=\"text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2109, "\"", 2123, 0);
            EndWriteAttribute();
            WriteLiteral(" readonly=\"readonly\">");
#nullable restore
#line 45 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
                                                                                             Write(Model.Variable);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 49 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
           Write(Html.LabelFor(model => model.Valor, htmlAttributes: new { @class = "col-md-2  pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"col-md-10\">\r\n                    <input class=\"form-control\" type=\"text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2481, "\"", 2495, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2496, "\"", 2516, 1);
#nullable restore
#line 52 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
WriteAttributeValue("", 2504, Model.Valor, 2504, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly=\"readonly\" />\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 56 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
           Write(Html.LabelFor(model => model.Estado, htmlAttributes: new { @class = "col-md-2  pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"col-md-10\">\r\n                    <input class=\"form-control\" type=\"text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2851, "\"", 2865, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2866, "\"", 2887, 1);
#nullable restore
#line 59 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
WriteAttributeValue("", 2874, Model.Estado, 2874, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly=\"readonly\" />\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                <div class=\"col-10 offset-2 \">\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 3069, "\"", 3115, 2);
#nullable restore
#line 64 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
WriteAttributeValue("", 3077, claseBotonCancelar, 3077, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3096, "deleteConfirmation", 3097, 19, true);
            EndWriteAttribute();
            WriteLiteral(">Eliminar </a>\r\n                    ");
#nullable restore
#line 65 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
               Write(Html.ActionLink("Editar", "Edit", "Configuracion", new { id = @Model.Id }, new { @class = claseBotonGuardar }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 68 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 72 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
 using (Html.BeginForm("Delete", "Configuracion", FormMethod.Post, new { @id = "frmDelete" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
                                      
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 85 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr.options.positionClass = \'toast-bottom-right\';\r\n                    toastr[\'");
#nullable restore
#line 87 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
                       Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 87 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Configuracion\Details.cshtml"
                                                   Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            }\r\n            });\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SISST.ViewModels.Comunes.Catalogos.VMConfiguracion> Html { get; private set; }
    }
}
#pragma warning restore 1591
