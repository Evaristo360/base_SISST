#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2dc413358683bef3bc9039f6193e72ff9fbd329"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Comunes_Views_Usuarios_Edit), @"mvc.1.0.view", @"/Areas/Comunes/Views/Usuarios/Edit.cshtml")]
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
#line 2 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
using SISST.ViewModels.Comunes.Usuarios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
using SISST.ViewModels.Privilegios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
using SISST.ViewModels.Comunes.Trabajadores;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2dc413358683bef3bc9039f6193e72ff9fbd329", @"/Areas/Comunes/Views/Usuarios/Edit.cshtml")]
    public class Areas_Comunes_Views_Usuarios_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SISST.ViewModels.Comunes.Usuarios.VMUsuario>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/viewer.part.bundle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/select2.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/datatable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/select2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Usuarios.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Utilities.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
   ViewData["Title"] = "Usuarios";
    Layout = "~/Views/Shared/_Layout.cshtml";
    string claseBotonGuardar = Context.Session.GetString("claseBotonGuardar");
    string claseBotonCancelar = Context.Session.GetString("claseBotonCancelar");


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card card-default\">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n            <div class=\"col-8\">\r\n                <h3 class=\"pl-3\">");
#nullable restore
#line 19 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <ol class=\"breadcrumb mb-0 \" style=\"background-color:white;\">\r\n                    <li class=\"breadcrumb-item\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 877, "\"", 943, 1);
#nullable restore
#line 22 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 884, Url.Action("Index", "Usuarios",  new { Area = "Comunes" }), 884, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Lista de usuarios</a>\r\n                    </li>\r\n                    <li class=\"breadcrumb-item \">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1072, "\"", 1154, 1);
#nullable restore
#line 25 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 1079, Url.Action("Details", "Usuarios",  new { Area = "Comunes", id= Model.Id }), 1079, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Detalle usuario</a>
                    </li>
                    <li class=""breadcrumb-item active"">
                        Editar usuario
                    </li>
                </ol>
            </div>
            <div class=""col-4 text-right mt-3"">
                ");
#nullable restore
#line 33 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
           Write(Html.ActionLink("Consulta de usuario", "Details", "Usuarios", new { Area = "Comunes", id = Model.Id }, new { @class = "btn btn_sistema" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"card card-default\">\r\n    <h4 class=\"card-header\">\r\n        Datos del usuario\r\n    </h4>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 43 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
         using (Html.BeginForm("Edit", "Usuarios", FormMethod.Post, new { @class = "form-horizontal", role = "form", autocomplete = "off", @id = "userData" }))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
       Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div role=""tabpanel"" class=""ie-fix-flex"">
                <ul class=""nav nav-tabs nav-justified"">
                    <li class=""nav-item"" role=""presentation"">
                        <a class=""nav-link active"" href=""#usuario"" role=""tab"" data-toggle=""tab"">
                            <span class=""number"">1.</span>
                            Usuario
                            <span id=""usuarioError""></span>
                        </a>
                    </li>
                    <li class=""nav-item"" role=""presentation"">
                        <a class=""nav-link"" href=""#roles"" role=""tab"" data-toggle=""tab"">
                            <span class=""number"">2.</span>
                            Roles
                            <span id=""rolesError""></span>
                        </a>
                    </li>
");
#nullable restore
#line 63 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                      
                        var StylePrivilegios = "";
                        if (!Model.IsAdmin)
                        {
                            StylePrivilegios = "display:none;";
                        }
                        ViewBag.StylePrivilegios = StylePrivilegios;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"nav-item\" role=\"presentation\"");
            BeginWriteAttribute("style", " style=\"", 3297, "\"", 3322, 1);
#nullable restore
#line 71 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 3305, StylePrivilegios, 3305, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                        <a class=""nav-link"" href=""#privilegios"" aria-controls=""picture"" role=""tab"" data-toggle=""tab"">
                            <span class=""number"">3.</span>
                            Privilegios
                        </a>
                    </li>

");
            WriteLiteral(@"                </ul>
                <div class=""tab-content"">
                    <div class=""tab-pane active"" id=""usuario"" role=""tabpanel"">
                        <br />
                        <fieldset>
                            <legend>Datos del usuario</legend>

                            <div class=""col-lg-12"">
                                <div class=""form-group row"">
                                    ");
#nullable restore
#line 93 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                               Write(Html.LabelFor(model => model.RPE, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label required-data" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <div class=\"col-md-10\">\r\n                                        ");
#nullable restore
#line 95 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.TextBoxFor(model => model.RPE, new { @readonly = "readonly", @class = "form-control", @disabled = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 96 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.HiddenFor(model => model.RPE, new { @id = "hdfRPE" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 97 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.HiddenFor(model => model.IdTrabajador, new { @id = "IdTrabajador" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <small style=\"color:cadetblue\"> </small><br />\r\n                                        ");
#nullable restore
#line 99 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.RPE, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"form-group row\">\r\n                                    ");
#nullable restore
#line 103 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                               Write(Html.LabelFor(model => model.Nombre, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <div class=\"col-md-10\">\r\n                                        ");
#nullable restore
#line 105 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.TextBoxFor(model => model.Nombre, new { @readonly = "readonly", @class = "form-control", @disabled = "true", @id = "txtNombre" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <small style=\"color:cadetblue\"> </small><br />\r\n                                        ");
#nullable restore
#line 107 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.Nombre, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n\r\n                                <div class=\"form-group row\">\r\n                                    ");
#nullable restore
#line 112 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                               Write(Html.LabelFor(model => model.Apellidos, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <div class=\"col-md-10\">\r\n                                        ");
#nullable restore
#line 114 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.TextBoxFor(model => model.Apellidos, new { @readonly = "readonly", @class = "form-control", @disabled = "true", @id = "txtApellidos" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <small style=\"color:cadetblue\"> </small><br />\r\n                                        ");
#nullable restore
#line 116 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.Apellidos, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n\r\n                                <div class=\"form-group row\">\r\n                                    ");
#nullable restore
#line 121 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                               Write(Html.LabelFor(model => model.Email, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <div class=\"col-md-10\">\r\n                                        ");
#nullable restore
#line 123 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.TextBoxFor(model => model.Email, new { @readonly = "readonly", @class = "form-control", @disabled = "true", @id = "txtCorreo" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <small style=\"color:cadetblue\"> </small><br />\r\n                                        ");
#nullable restore
#line 125 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n\r\n                                <div class=\"form-group row\">\r\n                                    ");
#nullable restore
#line 130 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                               Write(Html.LabelFor(model => model.Area, htmlAttributes: new { @class = "col-md-2 pl-5 col-form-label " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <div class=\"col-md-10\">\r\n                                        ");
#nullable restore
#line 132 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.TextBoxFor(model => model.claveAreaNombre, new { @readonly = "readonly", @class = "form-control", @disabled = "true", @id = "txtArea" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <small style=\"color:cadetblue\"> </small><br />\r\n                                        ");
#nullable restore
#line 134 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.Area, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n\r\n");
            WriteLiteral(@"                            </div>
                            <div class=""form-group row"">
                                <label class=""col-md-4 pl-5 col-form-label"">(*) Dato requerido.</label>
                            </div>
                        </fieldset>
                    </div>
                    <div class=""tab-pane"" id=""roles"" role=""tabpanel"">
                        <br />
                        <fieldset>
                            <legend>Asignaci??n de roles</legend>
                            ");
#nullable restore
#line 156 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                       Write(await Html.PartialAsync("_Roles", (List<VMAplicationRol>)Model.listaRoles, new ViewDataDictionary(ViewData) { { "accion", "crear" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </fieldset>\r\n                    </div>\r\n\r\n                    <div class=\"tab-pane\" id=\"privilegios\" role=\"tabpanel\"");
            BeginWriteAttribute("style", " style=\"", 9722, "\"", 9747, 1);
#nullable restore
#line 160 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 9730, StylePrivilegios, 9730, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <br />\r\n                        <fieldset");
            BeginWriteAttribute("style", " style=\"", 9816, "\"", 9841, 1);
#nullable restore
#line 162 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 9824, StylePrivilegios, 9824, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <legend>Asignaci??n de privilegios</legend>\r\n                            ");
#nullable restore
#line 164 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                       Write(await Html.PartialAsync("_Privilegios", (List<VMPrivilegio>)Model.listaPrivilegios, new ViewDataDictionary(ViewData) { { "accion", "crear" }, { "listaUsuarioPrivilegios", Model.listaUsuarioPrivilegios } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </fieldset>
                    </div>

                    <!--<div class=""tab-pane"" id=""centros"" role=""tabpanel"">
                    <br />
                    <fieldset>
                        <legend>Asignaci??n de centrales</legend>-->
");
            WriteLiteral("                    <!--</fieldset>\r\n                    </div>-->\r\n                </div>\r\n                <br>\r\n                <div class=\"form-group\">\r\n                    <div class=\"col-md-10 offset-2\">\r\n                        <button type=\"button\"");
            BeginWriteAttribute("class", " class=\"", 10822, "\"", 10854, 2);
#nullable restore
#line 179 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 10830, claseBotonCancelar, 10830, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 10849, "mr-1", 10850, 5, true);
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 10855, "\"", 10921, 3);
            WriteAttributeValue("", 10865, "location.href=\'", 10865, 15, true);
#nullable restore
#line 179 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 10880, Url.Action("Index", "Usuarios", new {}), 10880, 40, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10920, "\'", 10920, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-times pr-2\"></i>Cancelar</button>\r\n                        <button type=\"button\" onclick=\"sendForm()\"");
            BeginWriteAttribute("class", " class=\"", 11040, "\"", 11071, 2);
#nullable restore
#line 180 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 11048, claseBotonGuardar, 11048, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 11066, "mr-1", 11067, 5, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"btnAceptar\"><i class=\"fas fa-save pr-2\"></i> Guardar</button>\r\n                    </div>\r\n                </div>\r\n                <div id=\"divPrivilegioSeleccionado\"><input type=\"hidden\" name=\"listaPrivilegios\" id=\"listaPrivilegios\"");
            BeginWriteAttribute("value", " value=\"", 11310, "\"", 11318, 0);
            EndWriteAttribute();
            WriteLiteral(" /></div>\r\n                <div id=\"divRolSeleccionado\"><input type=\"hidden\" name=\"listaRol\" id=\"listaRol\"");
            BeginWriteAttribute("value", " value=\"", 11425, "\"", 11433, 0);
            EndWriteAttribute();
            WriteLiteral(" /></div>\r\n                <div id=\"divCentralSeleccionada\"></div>\r\n            </div>\r\n");
#nullable restore
#line 187 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
            DefineSection("BodyArea", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 191 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
     foreach (var rol in (List<VMAplicationRol>)Model.listaRoles)
    {
        string idModalM = "modalPrivilegio" + rol.Id;

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"modal inmodal\"");
                BeginWriteAttribute("id", " id=\"", 11737, "\"", 11751, 1);
#nullable restore
#line 194 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
WriteAttributeValue("", 11742, idModalM, 11742, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog modal-lg"">
                <div class=""modal-content animated fadeIn"">
                    <div class=""modal-header"">
                        <h4 class=""modal-title"">Privilegios del rol ");
#nullable restore
#line 198 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                                               Write(Html.Raw(rol.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                    </div>\r\n                    <div id=\"PrivilegioParcial\" class=\"modal-body modalPrivilegios\">\r\n                        ");
#nullable restore
#line 201 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                   Write(await Html.PartialAsync("_Privilegios", (List<VMPrivilegio>)rol.rolPrivilegio, new ViewDataDictionary(ViewData) { { "accion2", "detalle" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn_sistema desbloquearFormulario"" data-dismiss=""modal"">Aceptar</button>
                    </div>
                </div>
            </div>
        </div>
");
#nullable restore
#line 209 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c2dc413358683bef3bc9039f6193e72ff9fbd32928712", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c2dc413358683bef3bc9039f6193e72ff9fbd32929891", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c2dc413358683bef3bc9039f6193e72ff9fbd32931070", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2dc413358683bef3bc9039f6193e72ff9fbd32932370", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2dc413358683bef3bc9039f6193e72ff9fbd32933470", async() => {
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
                WriteLiteral("\r\n    <script src=\"https://cdn.jsdelivr.net/npm/jquery-ajax-unobtrusive@3.2.6/dist/jquery.unobtrusive-ajax.min.js\"></script>\r\n\r\n");
#nullable restore
#line 239 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("    <script type=\"text/javascript\">\r\n            var urlTrabajadoresSearch = \'");
#nullable restore
#line 241 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                    Write(Url.Action("GetAllPagination", "Trabajadores", new { Area = "Comunes" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n            var urlTrabajadorSearch = \'");
#nullable restore
#line 242 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                  Write(Url.Action("BusquedaRest", "Trabajadores", new { Area = "Comunes" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 245 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr.options.positionClass = \'toast-bottom-right\';\r\n                    toastr[\'");
#nullable restore
#line 247 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                       Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 247 "C:\Users\akwid\Desktop\base_SISST\SISST\Areas\Comunes\Views\Usuarios\Edit.cshtml"
                                                   Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                }\r\n\r\n            });\r\n    </script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2dc413358683bef3bc9039f6193e72ff9fbd32936781", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2dc413358683bef3bc9039f6193e72ff9fbd32937881", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SISST.ViewModels.Comunes.Usuarios.VMUsuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
