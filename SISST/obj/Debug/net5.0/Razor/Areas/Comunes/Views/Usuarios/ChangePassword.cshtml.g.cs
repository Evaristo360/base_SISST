#pragma checksum "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dface87f8bf965228c8b6c8e65702a33fb707ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Comunes_Views_Usuarios_ChangePassword), @"mvc.1.0.view", @"/Areas/Comunes/Views/Usuarios/ChangePassword.cshtml")]
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
#line 2 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
using SISST.ViewModels.Comunes.Usuarios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
using SISST.ViewModels.Privilegios;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dface87f8bf965228c8b6c8e65702a33fb707ef", @"/Areas/Comunes/Views/Usuarios/ChangePassword.cshtml")]
    public class Areas_Comunes_Views_Usuarios_ChangePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SISST.ViewModels.Comunes.Usuarios.VMUsuarioPassword>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/datatable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/select2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
  
    ViewData["Title"] = "Cambiar contraseña";
    Layout = "~/Views/Shared/_Layout.cshtml";
    string claseBotonGuardar = Context.Session.GetString("claseBotonGuardar");
    string claseBotonCancelar = Context.Session.GetString("claseBotonCancelar");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card card-default\">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n            <div class=\"col-8\">\r\n                <h3 class=\"pl-3\">");
#nullable restore
#line 17 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <ol class=\"breadcrumb mb-0 \" style=\"background-color:white;\">\r\n                    <li class=\"breadcrumb-item\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 825, "\"", 891, 1);
#nullable restore
#line 20 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
WriteAttributeValue("", 832, Url.Action("Index", "Usuarios",  new { Area = "Comunes" }), 832, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Lista de usuarios</a>
                    </li>
                    <li class=""breadcrumb-item active"">
                        Cambiar contraseña
                    </li>
                </ol>
            </div>
            <div class=""col-4 text-right mt-3"">
                ");
#nullable restore
#line 28 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
           Write(Html.ActionLink("Lista de usuarios", "Index", "Usuarios", null, new { @class = "btn btn_sistema" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"card card-default\">\r\n    <h4 class=\"card-header\">\r\n        Cambiar contraseña\r\n    </h4>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 38 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
         using (Html.BeginForm("ChangePassword", "Usuarios", FormMethod.Post, new { @class = "form-horizontal", role = "form", autocomplete = "off" }))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
       Write(Html.HiddenFor(model => model.Id ));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-12\">\r\n                <div class=\"form-group row\">\r\n                    ");
#nullable restore
#line 46 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
               Write(Html.LabelFor(model => model.RPE, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 48 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                   Write(Html.TextBoxFor(model => model.RPE, new { @readonly = "readonly", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br />\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"form-group row\">\r\n                    ");
#nullable restore
#line 54 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
               Write(Html.LabelFor(model => model.Nombre, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 56 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                   Write(Html.TextBoxFor(model => model.Nombre, new { @readonly = "readonly", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br />\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    ");
#nullable restore
#line 61 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
               Write(Html.LabelFor(model => model.Apellidos, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 63 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                   Write(Html.TextBoxFor(model => model.Apellidos, new { @readonly = "readonly", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br />\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    ");
#nullable restore
#line 68 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
               Write(Html.LabelFor(model => model.Password, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 70 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                   Write(Html.PasswordFor(model => model.Password, new { @class = "form-control required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br />\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group row\">\r\n                    ");
#nullable restore
#line 75 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
               Write(Html.LabelFor(model => model.PasswordConfirm, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 77 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                   Write(Html.PasswordFor(model => model.PasswordConfirm, new { @class = "form-control required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <br />
                    </div>
                </div>
            </div>
            <div class=""form-group"">
                <div class="" col-md-10 offset-2"">
                    <div class=""col-md-10 offset-2"">
                        <button type=""button""");
            BeginWriteAttribute("class", " class=\"", 4147, "\"", 4179, 2);
#nullable restore
#line 85 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
WriteAttributeValue("", 4155, claseBotonCancelar, 4155, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 4174, "mr-1", 4175, 5, true);
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 4180, "\"", 4247, 3);
            WriteAttributeValue("", 4190, "location.href=\'", 4190, 15, true);
#nullable restore
#line 85 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
WriteAttributeValue("", 4205, Url.Action("Index", "Usuarios", new { }), 4205, 41, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4246, "\'", 4246, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-times pr-2\"></i>Cancelar</button>\r\n                        <button type=\"submit\"");
            BeginWriteAttribute("class", " class=\"", 4345, "\"", 4376, 2);
#nullable restore
#line 86 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
WriteAttributeValue("", 4353, claseBotonGuardar, 4353, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 4371, "mr-1", 4372, 5, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-save pr-2\"></i> Guardar</button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 90 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1dface87f8bf965228c8b6c8e65702a33fb707ef14173", async() => {
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
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dface87f8bf965228c8b6c8e65702a33fb707ef15473", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dface87f8bf965228c8b6c8e65702a33fb707ef16573", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 101 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr.options.positionClass = \'toast-bottom-right\';\r\n                    toastr[\'");
#nullable restore
#line 103 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                       Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 103 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Usuarios\ChangePassword.cshtml"
                                                   Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                }\r\n            });\r\n    </script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SISST.ViewModels.Comunes.Usuarios.VMUsuarioPassword> Html { get; private set; }
    }
}
#pragma warning restore 1591
