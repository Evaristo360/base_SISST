#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a4c7ec7623a3f71c3706c8d1d663db573d8bf22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Comunes_Views_Catalogos_Details), @"mvc.1.0.view", @"/Areas/Comunes/Views/Catalogos/Details.cshtml")]
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
#line 2 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a4c7ec7623a3f71c3706c8d1d663db573d8bf22", @"/Areas/Comunes/Views/Catalogos/Details.cshtml")]
    public class Areas_Comunes_Views_Catalogos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SISST.ViewModels.Comunes.Catalogos.VMCatalogoOpciones>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Comunes/Catalogos/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/datatable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
   ViewData["Title"] = "Consulta de catálogo";
    Layout = "~/Views/Shared/_Layout.cshtml";
    string claseBotonGuardar = Context.Session.GetString("claseBotonGuardar");
    string claseBotonCancelar = Context.Session.GetString("claseBotonCancelar");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card card-default\">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n            <div class=\"col-8\">\r\n                <h3 class=\"pl-3\">Catálogo ");
#nullable restore
#line 14 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                     Write(Model.Catalogo.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <ol class=\"breadcrumb mb-0 \" style=\"background-color:white;\">\r\n                    <li class=\"breadcrumb-item\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a4c7ec7623a3f71c3706c8d1d663db573d8bf225362", async() => {
                WriteLiteral("Lista de catálogos");
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
            WriteLiteral("\r\n                    </li>\r\n                    <li class=\"breadcrumb-item active\">Consulta de catálogo</li>\r\n                </ol>\r\n            </div>\r\n            <div class=\"col-4 text-right mt-3\">\r\n                ");
#nullable restore
#line 23 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
           Write(Html.ActionLink("Lista de catálogos", "Index", "Catalogos", null, new { @class = "btn btn_sistema" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"card card-default\">\r\n    <h4 class=\"card-header\">Consulta del catálogo</h4>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 32 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
         using (Html.BeginForm())
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 37 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
           Write(Html.LabelFor(model => model.Catalogo.Nombre, htmlAttributes: new { @class = "col-md-2  pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    <input class=\"form-control\" type=\"text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 1729, "\"", 1743, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1744, "\"", 1774, 1);
#nullable restore
#line 39 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
WriteAttributeValue("", 1752, Model.Catalogo.Nombre, 1752, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly=\"readonly\" />\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 43 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
           Write(Html.LabelFor(model => model.Catalogo.Descripcion, htmlAttributes: new { @class = "col-md-2  pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    <textarea class=\"form-control autoResize\" type=\"text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2135, "\"", 2149, 0);
            EndWriteAttribute();
            WriteLiteral(" readonly=\"readonly\">");
#nullable restore
#line 45 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                                                                                        Write(Model.Catalogo.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 49 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
           Write(Html.LabelFor(model => model.Catalogo.Estado, htmlAttributes: new { @class = "col-md-2  pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    <input class=\"form-control\" type=\"text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2527, "\"", 2541, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2542, "\"", 2580, 1);
#nullable restore
#line 51 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
WriteAttributeValue("", 2550, Model.Catalogo.EtiquetaEstado, 2550, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly=\"readonly\" />\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                <div class=\"col-10 offset-2 \">\r\n                    <button type=\"button\"");
            BeginWriteAttribute("class", " class=\"", 2781, "\"", 2832, 3);
#nullable restore
#line 56 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
WriteAttributeValue("", 2789, claseBotonCancelar, 2789, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2808, "deleteConfirmation", 2809, 19, true);
            WriteAttributeValue(" ", 2827, "mr-1", 2828, 5, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-trash-alt pr-2\"></i>Eliminar</button>\r\n                    <button type=\"button\"");
            BeginWriteAttribute("class", " class=\"", 2931, "\"", 2962, 2);
#nullable restore
#line 57 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
WriteAttributeValue("", 2939, claseBotonGuardar, 2939, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2957, "mr-1", 2958, 5, true);
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 2963, "\"", 3070, 3);
            WriteAttributeValue("", 2973, "location.href=\'", 2973, 15, true);
#nullable restore
#line 57 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
WriteAttributeValue("", 2988, Url.Action("Edit", "Catalogos", new { Area = "Comunes", id = Model.IdCatalogo }), 2988, 81, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3069, "\'", 3069, 1, true);
            EndWriteAttribute();
            WriteLiteral("> <i class=\"fa fa-edit pr-2\"></i> Editar</button>\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("        <div class=\"card card-default\">\r\n            <div class=\"card-header\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-8\">\r\n                        <h4 class=\"card-title\">Opciones del catálogo  ");
#nullable restore
#line 66 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                                                 Write(Model.Catalogo.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                    </div>\r\n                    <div class=\"col-4 text-right\">\r\n                        <button type=\"button\"");
            BeginWriteAttribute("class", " class=\"", 3601, "\"", 3632, 2);
#nullable restore
#line 69 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
WriteAttributeValue("", 3609, claseBotonGuardar, 3609, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3627, "mr-1", 3628, 5, true);
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 3633, "\"", 3748, 3);
            WriteAttributeValue("", 3643, "location.href=\'", 3643, 15, true);
#nullable restore
#line 69 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
WriteAttributeValue("", 3658, Url.Action("CreateOpcion", "Catalogos", new { Area = "Comunes", id = Model.IdCatalogo }), 3658, 89, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3747, "\'", 3747, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"> <i class=""fa fa-plus-circle pr-2""></i> Nueva opción</button>
                    </div>
                </div>
            </div>
            <div class=""card-body"">
                <table class=""table table-striped my-4 w-100 border-gray border dataTables-example"">
                    <thead>
                        <tr>
                            <th>Orden</th>
                            <th>Nombre</th>
                            <th>Clave</th>
                            <th>Proceso</th>
                            <th class=""sort-alpha"">Estado</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 85 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                         foreach (var item in Model.Opciones)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr");
            BeginWriteAttribute("class", " class=\"", 4537, "\"", 4578, 1);
#nullable restore
#line 87 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
WriteAttributeValue("", 4545, item.Opcion.EsSeleccionableClase, 4545, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <td>");
#nullable restore
#line 88 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                               Write(item.Opcion.Orden);

#line default
#line hidden
#nullable disable
            WriteLiteral(".0</td>\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a4c7ec7623a3f71c3706c8d1d663db573d8bf2216056", async() => {
#nullable restore
#line 89 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                                                                                                                   Write(item.Opcion.Nombre);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4690, "~/Comunes/Catalogos/DetailsOpcion?id=", 4690, 37, true);
#nullable restore
#line 89 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
AddHtmlAttributeValue("", 4727, item.Opcion.IdCatalogo, 4727, 23, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 4750, "&IdCatalogo=", 4750, 12, true);
#nullable restore
#line 89 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
AddHtmlAttributeValue("", 4762, Model.IdCatalogo, 4762, 17, false);

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
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 90 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                               Write(item.Opcion.Clave);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 91 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                               Write(item.Opcion.Proceso);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 92 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                               Write(item.Opcion.EtiquetaEstado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 94 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                             foreach (var subitem in item.Subopciones)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 97 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                   Write(item.Opcion.Orden);

#line default
#line hidden
#nullable disable
            WriteLiteral(".");
#nullable restore
#line 97 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                                      Write(subitem.Orden);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><span class=\"ml-3\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a4c7ec7623a3f71c3706c8d1d663db573d8bf2220162", async() => {
#nullable restore
#line 98 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                                                                                                                                      Write(subitem.Nombre);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5329, "~/Comunes/Catalogos/DetailsOpcion?id=", 5329, 37, true);
#nullable restore
#line 98 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
AddHtmlAttributeValue("", 5366, subitem.IdCatalogo, 5366, 19, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 5385, "&IdCatalogo=", 5385, 12, true);
#nullable restore
#line 98 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
AddHtmlAttributeValue("", 5397, Model.IdCatalogo, 5397, 17, false);

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
            WriteLiteral("</span></td>\r\n                                    <td>");
#nullable restore
#line 99 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                   Write(subitem.Clave);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 100 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                   Write(subitem.Proceso);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 101 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                   Write(subitem.EtiquetaEstado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 103 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 109 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 113 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
 using (Html.BeginForm("Delete", "Catalogos", FormMethod.Post, new { @id = "frmDelete" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
Write(Html.HiddenFor(model => model.IdCatalogo));

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                              
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1a4c7ec7623a3f71c3706c8d1d663db573d8bf2225151", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 125 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("    <script>\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 128 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr.options.positionClass = \'toast-bottom-right\';\r\n                    toastr[\'");
#nullable restore
#line 130 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                       Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 130 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Catalogos\Details.cshtml"
                                                   Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            }\r\n            });\r\n    </script>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a4c7ec7623a3f71c3706c8d1d663db573d8bf2227826", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SISST.ViewModels.Comunes.Catalogos.VMCatalogoOpciones> Html { get; private set; }
    }
}
#pragma warning restore 1591