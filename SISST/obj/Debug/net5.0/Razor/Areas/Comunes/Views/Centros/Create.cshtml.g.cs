#pragma checksum "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ac6de9b18a93cf1b48744538a720330ebdf7c67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Comunes_Views_Centros_Create), @"mvc.1.0.view", @"/Areas/Comunes/Views/Centros/Create.cshtml")]
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
#line 2 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
using SISST.ViewModels.Comunes.Areas;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ac6de9b18a93cf1b48744538a720330ebdf7c67", @"/Areas/Comunes/Views/Centros/Create.cshtml")]
    public class Areas_Comunes_Views_Centros_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SISST.ViewModels.Comunes.Areas.VMArea>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/select2.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/datatable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/select2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Centros.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
  
    ViewData["Title"] = "Catálogo de centros de trabajo";
    Layout = "~/Views/Shared/_Layout.cshtml";
    string claseBotonGuardar = Context.Session.GetString("claseBotonGuardar");
    string claseBotonCancelar = Context.Session.GetString("claseBotonCancelar");

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card  card-default\">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n            <div class=\"col-8\">\r\n                <h3 class=\"pl-3\">");
#nullable restore
#line 15 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <ol class=\"breadcrumb mb-0 \" style=\"background-color:white;\">\r\n                    <li class=\"breadcrumb-item\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 782, "\"", 847, 1);
#nullable restore
#line 18 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
WriteAttributeValue("", 789, Url.Action("Index", "Centros",  new { Area = "Comunes" }), 789, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Lista de centros de trabajo</a>\r\n                    </li>\r\n                    <li class=\"breadcrumb-item active\">Crear centros de trabajo</li>\r\n                </ol>\r\n            </div>\r\n            <div class=\"col-4 text-right mt-3\">\r\n                ");
#nullable restore
#line 24 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.ActionLink("Lista de centros de trabajo", "Index", "Centros", new { Area = "Comunes" }, new { @class = "btn btn_sistema" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"card card-default\">\r\n    <h4 class=\"card-header\">\r\n        Datos del centro de trabajo\r\n    </h4>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 34 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
         using (Html.BeginForm("Create", "Centros", new { Area = "Comunes" }, FormMethod.Post, true, new { @class = "form-horizontal", role = "form", autocomplete = "off" }))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 38 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.Clave, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 40 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.TextBoxFor(model => model.Clave, new { @class = "form-control", @maxlength = "5", id = "ClaveCentroTrabajo" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <small style=\"color:cadetblue\"> </small>\r\n                    ");
#nullable restore
#line 42 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Clave, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 46 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.Nombre, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 48 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.TextBoxFor(model => model.Nombre, new { @class = "form-control", @maxlength = "100" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <small style=\"color:cadetblue\"> </small>\r\n                    ");
#nullable restore
#line 50 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Nombre, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 54 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.IdAreaSuperior, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 56 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.DropDownListFor(model => model.IdAreaSuperior, (IEnumerable<SelectListItem>
              )Model.listaAreas, "Seleccione...", new { @class = "form-control chosen-select areaSearch required", @id = "areaSuperior" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 58 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.IdAreaSuperior, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 63 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.IdAreaVerificacion, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 65 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.DropDownListFor(model => model.IdAreaVerificacion, (IEnumerable<SelectListItem>
             )Model.listaAreas, "Seleccione...", new { @class = "form-control chosen-select areaSearch", @id = "areaVerificacion" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 67 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.IdAreaVerificacion, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 71 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.IdProceso, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 73 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.DropDownListFor(model => model.IdProceso, (IEnumerable<SelectListItem>
                  )Model.listaProcesos, "Seleccione...", new { @class = "form-control chosen-select select2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 75 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.IdProceso, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 79 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.CentroGestor, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 81 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.TextBoxFor(model => model.CentroGestor, new { @class = "form-control", @maxlength = "100" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <small style=\"color:cadetblue\"> </small>\r\n                    ");
#nullable restore
#line 83 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.CentroGestor, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 87 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.ClaveControlGestion, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 89 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.TextBoxFor(model => model.ClaveControlGestion, new { @class = "form-control", @maxlength = "7", id = "ClaveControlGestion" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <small style=\"color:cadetblue\"> </small>\r\n                    ");
#nullable restore
#line 91 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.ClaveControlGestion, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 95 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.Prioridad, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 97 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.DropDownListFor(model => model.Prioridad, (IEnumerable<SelectListItem>
                  )Model.listaPrioridad, "Seleccione...", new { @class = "form-control chosen-select select2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 99 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Prioridad, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div> \r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 103 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.IdNivelJerarquico, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 105 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.DropDownListFor(model => model.IdNivelJerarquico, (IEnumerable<SelectListItem>
                  )Model.listaNivelJerarquico, "Seleccione...", new { @class = "form-control chosen-select select2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 107 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.IdNivelJerarquico, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 112 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(m => m.GeneraDatosBasicos, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                <div class=\"form-check-inline\">\r\n                    <label class=\"form-check-label\">\r\n                        ");
#nullable restore
#line 115 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                   Write(Html.RadioButtonFor(m => m.GeneraDatosBasicos, true, new { @class = "form-check-input", @id = "btnGDBSi" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 116 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                   Write(Html.LabelFor(m => m.GeneraDatosBasicos, "Sí"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </label>\r\n                </div>\r\n                <div class=\"form-check-inline\">\r\n                    <label class=\"form-check-label\">\r\n                        ");
#nullable restore
#line 121 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                   Write(Html.RadioButtonFor(m => m.GeneraDatosBasicos, false, new { @class = "form-check-input", @id = "btnGDBNo" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 122 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                   Write(Html.LabelFor(m => m.GeneraDatosBasicos, "No"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </label>\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 127 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.Direccion, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 129 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.TextBoxFor(model => model.Direccion, new { @class = "form-control", @maxlength = "100" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <small style=\"color:cadetblue\"> </small>\r\n                    ");
#nullable restore
#line 131 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Direccion, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 135 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.IdEntidadFederativa, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 137 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.DropDownListFor(model => model.IdEntidadFederativa, (IEnumerable<SelectListItem>
                  )Model.listaEntidadFederativa, "Seleccione...", new { @class = "form-control chosen-select select2", id = "entidadFederativa" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 139 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.IdEntidadFederativa, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 143 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.IdMunicipio, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 145 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.DropDownListFor(model => model.IdMunicipio, (IEnumerable<SelectListItem>
                    )Model.listaMunicipio, "Seleccione...", new { @class = "form-control chosen-select select2", id = "municipios" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 147 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.IdMunicipio, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 151 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
           Write(Html.LabelFor(model => model.Telefono, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 153 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.TextBoxFor(model => model.Telefono, new { @class = "form-control", @maxlength = "100" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <small style=\"color:cadetblue\"> </small>\r\n                    ");
#nullable restore
#line 155 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Telefono, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 158 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
       Write(Html.HiddenFor(model => model.Activo, new { value = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""form-group row"">
                <label class=""col-md-4 pl-5 col-form-label"">(*) Dato requerido.</label>
            </div>
            <div class=""form-group row"">
                <div class=""col-md-10 offset-2"">
                    <button type=""button""");
            BeginWriteAttribute("class", " class=\"", 10578, "\"", 10610, 2);
#nullable restore
#line 164 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
WriteAttributeValue("", 10586, claseBotonCancelar, 10586, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 10605, "mr-1", 10606, 5, true);
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 10611, "\"", 10676, 3);
            WriteAttributeValue("", 10621, "location.href=\'", 10621, 15, true);
#nullable restore
#line 164 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
WriteAttributeValue("", 10636, Url.Action("Index", "Centros", new {}), 10636, 39, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10675, "\'", 10675, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-times pr-2\"></i>Cancelar</button>\r\n                    <button type=\"submit\"");
            BeginWriteAttribute("class", " class=\"", 10770, "\"", 10801, 2);
#nullable restore
#line 165 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
WriteAttributeValue("", 10778, claseBotonGuardar, 10778, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 10796, "mr-1", 10797, 5, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-save pr-2\"></i> Guardar</button>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 168 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 10939, "\"", 10947, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"hdfSeleccionado\" />\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6ac6de9b18a93cf1b48744538a720330ebdf7c6728261", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6ac6de9b18a93cf1b48744538a720330ebdf7c6729440", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac6de9b18a93cf1b48744538a720330ebdf7c6730740", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac6de9b18a93cf1b48744538a720330ebdf7c6731840", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 181 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    var urlAreasSearch = \'");
#nullable restore
#line 184 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                     Write(Url.Action("SearchAll", "Centros", new { Area = "Comunes" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n    var getOpcionesCatalogoUrl = \'");
#nullable restore
#line 185 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                             Write(Url.Action("GetOpciones", "Centros", new { Area = "Comunes" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n    console.log(getOpcionesCatalogoUrl);\r\n\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 189 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr[\'");
#nullable restore
#line 190 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                       Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 190 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\Centros\Create.cshtml"
                                                   Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
                }

                $(""#entidadFederativa"").on('change', function (e) {
                    var optionSelected = $(this).find(""option:selected"");
                    var idSelected = optionSelected.val();
                    $(""#municipios"").empty();

                    json_mvc(getOpcionesCatalogoUrl + '/' + idSelected,
                        """", ""GET"", function (municipios) {
                            
                            $.each(municipios, function (i, municipio) {
                                console.log(""=>"", municipio.nombre);
                                $(""#municipios"").append('<option value=""'
                                    + municipio.idCatalogo + '"">'
                                    + municipio.nombre + '</option>');
                            });
                        });                    
                });

                $(""#tipoInstalacion"").on('change', function (e) {
                    var optionSelected = $(this).fin");
                WriteLiteral(@"d(""option:selected"");
                    var idSelected = optionSelected.val();
                    $(""#subTipoInstalacion"").empty();

                    $.ajax({
                        type: 'GET',
                        url: getOpcionesCatalogoUrl + '/' + idSelected,
                        dataType: 'json',
                        success: function (municipios) {
                            $.each(municipios, function (i, municipio) {
                                console.log(""=>"", municipio.nombre);
                                $(""#subTipoInstalacion"").append('<option value=""'
                                    + municipio.idCatalogo + '"">'
                                    + municipio.nombre + '</option>');
                            });
                        }
                    });
                });
            });
</script>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ac6de9b18a93cf1b48744538a720330ebdf7c6736735", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SISST.ViewModels.Comunes.Areas.VMArea> Html { get; private set; }
    }
}
#pragma warning restore 1591
