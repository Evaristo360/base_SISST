#pragma checksum "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "782141a6f3baf476e34d0585a112325618645cd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Gestion_Views_ReunionesDeDifusion_Put), @"mvc.1.0.view", @"/Areas/Gestion/Views/ReunionesDeDifusion/Put.cshtml")]
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
#line 2 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"782141a6f3baf476e34d0585a112325618645cd0", @"/Areas/Gestion/Views/ReunionesDeDifusion/Put.cshtml")]
    public class Areas_Gestion_Views_ReunionesDeDifusion_Put : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SISST.Areas.Gestion.Models.ModelosDeDifusion.VMIndex>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/CreateReunion.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
  
    ViewData["Title"] = "Nueva Reunion";
    Layout = "~/Views/Shared/_Layout.cshtml";
    //no se que onda pero ya los puse si no pues los borro
    string claseBotonGuardar = Context.Session.GetString("claseBotonGuardar");
    string claseBotonCancelar = Context.Session.GetString("claseBotonCancelar");

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "782141a6f3baf476e34d0585a112325618645cd04556", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "782141a6f3baf476e34d0585a112325618645cd04818", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "782141a6f3baf476e34d0585a112325618645cd05996", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""row"">

    <div class=""col-12"">
        <div class=""card w-100 tarjetaprincipal"">
            <div class=""card-body"">
                <h5 class=""card-title titulos"">Desarrollo de reunión o plática de difusión</h5>
                <div class=""row"">
                    <div class=""col-6"">
                        <p class=""subtitulos"">Completa cuidadosamente todos los espacios</p>
                    </div>
                    <div class=""col-6"" align=""right"">
");
            WriteLiteral("                        <button type=\"button\"");
            BeginWriteAttribute("class", " class=\"", 1472, "\"", 1499, 1);
#nullable restore
#line 29 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 1480, claseBotonCancelar, 1480, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1500, "\"", 1577, 3);
            WriteAttributeValue("", 1510, "location.href=\'", 1510, 15, true);
#nullable restore
#line 29 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 1525, Url.Action("Index", "ReunionesDeDifusion", new {}), 1525, 51, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1576, "\'", 1576, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-times pr-2\"></i>Regresar</button>\r\n                        <button type=\"submit\"");
            BeginWriteAttribute("class", " class=\"", 1675, "\"", 1706, 2);
#nullable restore
#line 30 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 1683, claseBotonGuardar, 1683, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1701, "mr-1", 1702, 5, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-save pr-2\"></i> Modificar</button>\r\n                        <button type=\"submit\"");
            BeginWriteAttribute("class", " class=\"", 1806, "\"", 1837, 2);
#nullable restore
#line 31 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 1814, claseBotonGuardar, 1814, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1832, "mr-1", 1833, 5, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-save pr-2\"></i> Reporte</button>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 34 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                 using (Html.BeginForm("Create", "ReunionesDeDifusion", FormMethod.Post, new { role = "form", autocomplete = "off" }))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <!--Inico de primera parte del formulario-->
                    <div class=""card w-100"">
                        <div class=""card-body"">
                            <h5 class=""card-title"">Datos generales</h5>
                            <div class=""row"">

                                <div class=""col-6"">

                                    <div class=""form-group col-md-8"">
                                        <label class=""texto"">Centro trabajo *</label>
                                        <input type=""text"" class=""form-control""");
            BeginWriteAttribute("id", " id=\"", 2718, "\"", 2723, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled>
                                    </div>

                                    <div class=""form-group col-md-8"">
                                        <label class=""texto"">Departamento *</label>
                                        <select class=""form-control"">
                                            <option value=""value"">Dep Pruebas</option>
                                        </select>
                                    </div>

                                    <div class=""form-group col-md-10 "">
                                        <label class=""texto"">Vo Bo (Jefe de Departamento) *</label>
                                        <div class=""row"">
                                            <div class=""col-2"" align=""center"">
                                                <input type=""text"" class=""form-control""");
            BeginWriteAttribute("id", " id=\"", 3594, "\"", 3599, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"12ER\">\r\n                                            </div>\r\n                                            <input type=\"text\" class=\"form-control col-md-7\"");
            BeginWriteAttribute("id", " id=\"", 3766, "\"", 3771, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Prueba VoBo\">\r\n                                            <button type=\"button\" style=\"margin-left:2px\"");
            BeginWriteAttribute("class", " class=\"", 3890, "\"", 3917, 1);
#nullable restore
#line 64 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 3898, claseBotonCancelar, 3898, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-list""></i></button>

                                            <!--  <button style=""margin-left:2px"">List</button>-->
                                        </div>
                                    </div>

                                    <div class=""form-group col-md-8"">
                                        <label class=""texto"">Horario *</label>
                                        ");
#nullable restore
#line 72 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                                   Write(Html.TextBoxFor(model => model.Horario, new { @class = "form-control", @maxlength = "255" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        ");
#nullable restore
#line 73 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                                   Write(Html.ValidationMessageFor(model => model.Horario, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </div>
                                </div>
                                <br /><br />

                                <div class=""col-6"">
                                    <div class=""form-group col-md-8"">
                                        <label class=""texto"">Fecha *</label>
                                        <input type=""Date"" class=""form-control""");
            BeginWriteAttribute("id", " id=\"", 4979, "\"", 4984, 0);
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""10:30"">
                                    </div>

                                    <div class=""form-group col-md-10 "">
                                        <label class=""texto"">Coordinador de servicio o expositor de plática *</label>
                                        <div class=""row"">
                                            <div class=""col-2"" align=""center"">
                                                <input type=""text"" class=""form-control""");
            BeginWriteAttribute("id", " id=\"", 5472, "\"", 5477, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"3894\">\r\n                                            </div>\r\n                                            <input type=\"text\" class=\"form-control col-md-7\"");
            BeginWriteAttribute("id", " id=\"", 5644, "\"", 5649, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Ing. Prueba\">\r\n\r\n                                            <button type=\"button\"");
            BeginWriteAttribute("class", " class=\"", 5746, "\"", 5773, 1);
#nullable restore
#line 92 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 5754, claseBotonCancelar, 5754, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" data-toggle=""modal"" data-target=""#modalLoad""><i class=""fa fa-list""></i></button>

                                        </div>
                                    </div>

                                    <div class=""form-group col-md-10 "">
                                        <label class=""texto"">Revisó (Coordinador sistema Gestion) *</label>
                                        <div class=""row"">
                                            <div class=""col-2"" align=""center"">
                                                <input type=""text"" class=""form-control""");
            BeginWriteAttribute("id", " id=\"", 6361, "\"", 6366, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"4334\">\r\n                                            </div>\r\n                                            <input type=\"text\" class=\"form-control col-md-7\"");
            BeginWriteAttribute("id", " id=\"", 6533, "\"", 6538, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Ing. Guillermo\">\r\n\r\n                                            <button type=\"button\" style=\"margin-left:2px\"");
            BeginWriteAttribute("class", " class=\"", 6662, "\"", 6689, 1);
#nullable restore
#line 105 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 6670, claseBotonCancelar, 6670, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-list""></i></button>

                                        </div>
                                    </div>

                                    <div class=""form-group col-md-10 "">
                                        <label class=""texto"">Numero de participantes *</label>
                                        <div class=""row"">
                                            <div class=""col-5"" align=""center"">
                                                <input type=""text"" class=""form-control""");
            BeginWriteAttribute("id", " id=\"", 7219, "\"", 7224, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"10\">\r\n                                            </div>\r\n                                            <button type=\"button\" style=\"margin-left:2px\"");
            BeginWriteAttribute("class", " class=\"", 7386, "\"", 7413, 1);
#nullable restore
#line 116 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 7394, claseBotonCancelar, 7394, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-list""></i> Participantes</button>

                                        </div>
                                    </div>


                                </div>
                            </div>
                            <div class=""form-group col-md-10"">
                                <label class=""texto"">Tema *</label>
                                ");
#nullable restore
#line 126 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.TextAreaFor(model => model.Tema, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 127 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Tema, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                            </div>
                        </div>
                    </div>
                    <!--Iniico seguna partye del formulario-->
                    <div class=""card w-100"">
                        <div class=""card-body"">
                            <h5 class=""card-title subtitulos"">Apoyo didactico usado</h5>
                            <br />
                            <p class=""texto"">Seleccion Multiple</p>
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""checkbox"" id=""inlineCheckbox1"" value=""option1"">
                                <label class=""form-check-label"" for=""inlineCheckbox1"">Proyector de Cañon</label>
                            </div>
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""checkbox"" id=""inlineCheckbox2"" value=""option2"">
                                <label");
            WriteLiteral(@" class=""form-check-label"" for=""inlineCheckbox2"">Computadora</label>
                            </div>
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""checkbox"" id=""inlineCheckbox3"" value=""option3"">
                                <label class=""form-check-label"" for=""inlineCheckbox3"">Rotafolios</label>
                            </div>
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""checkbox"" id=""inlineCheckbox3"" value=""option3"">
                                <label class=""form-check-label"" for=""inlineCheckbox3"">Pizarron</label>
                            </div>
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""checkbox"" id=""inlineCheckbox3"" value=""option3"">
                                <label class=""form-check-label"" ");
            WriteLiteral(@"for=""inlineCheckbox3"">Rreproductor DVD</label>
                            </div>
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""checkbox"" id=""inlineCheckbox3"" value=""option3"">
                                <label class=""form-check-label"" for=""inlineCheckbox3"">Otro</label>
                            </div>
                        </div>
                    </div>
                    <!-- inicio tercera parte del formulario-->
                    <div class=""card w-100"">
                        <div class=""card-body"">
                            <h5 class=""card-title subtitulos"">Desarrollo del tema</h5>
                            <div class=""form-group col-md-10"">
                                <label class=""texto"">Introduccion *</label>

                                ");
#nullable restore
#line 171 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.TextAreaFor(model => model.Introduccion, new { @class = "form-control", @maxlength = "255" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 172 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Introduccion, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </div>\r\n                            <div class=\"form-group col-md-10\">\r\n                                <label class=\"texto\">Desarrollo *</label>\r\n\r\n                                ");
#nullable restore
#line 178 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.TextAreaFor(model => model.Desarrollo, new { @class = "form-control", @maxlength = "255" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 179 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Desarrollo, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </div>\r\n                            <div class=\"form-group col-md-10\">\r\n                                <label class=\"texto\">Conclusión *</label>\r\n\r\n                                ");
#nullable restore
#line 185 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.TextAreaFor(model => model.Conclusiones, new { @class = "form-control", @maxlength = "255" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 186 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Conclusiones, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            WriteLiteral(@"                    <!-- inicio cuarta parte-->
                    <div class=""card w-100"">
                        <div class=""card-body"">
                            <h5 class=""card-title subtitulos"">Comentarios y conclusiones (retroalimentacion)</h5>
                            <div class=""form-group col-md-10"">
                                <label class=""texto"">Retroalimentacion *</label>

                                ");
#nullable restore
#line 199 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.TextAreaFor(model => model.Retroalimentacion, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 200 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Retroalimentacion, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 205 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <!--parte final-->
                <div class=""card w-100"">
                    <div class=""card-body"">
                        <h5 class=""card-title subtitulos"">Generacion de correcciones SST</h5>
                        <p class=""texto""> Desarrollo de la reunion se requiere los siguientes formatos 13  </p>
                        <div class=""form-group col-md-10 "">
                            <div class=""row"">
                                <div class=""col-5"" align=""center"">
                                    <input type=""text"" class=""form-control""");
            BeginWriteAttribute("id", " id=\"", 13487, "\"", 13492, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </div>\r\n                                <button type=\"button\" style=\"margin-left:2px\"");
            BeginWriteAttribute("class", " class=\"", 13613, "\"", 13640, 1);
#nullable restore
#line 217 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
WriteAttributeValue("", 13621, claseBotonCancelar, 13621, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-save""></i> Agregar</button>

                            </div>
                        </div>
                        <br />
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th>Eliminar</th>
                                    <th align=""center""><b>Seguimiento en F13</b></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><i class=""fas fa-trash""></i></td>
                                    <td>Texto de prueba</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div><!--ginal de la quibta parte-->

            </div>
        </div>
    </div><!--Final de segunda coliumna-->
</div><!--final del row-->
<!--Modal para la p");
            WriteLiteral(@"irmera a ver que rollo jaja-->
<div class=""modal fade "" id=""modalLoad"" tabindex=""1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""modalLoad"">Modal title</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-6"">
                        <input type=""text"" name=""nombre"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 15382, "\"", 15390, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                    </div>
                    <div class=""col-6"">
                        <i class=""fas fa-search""></i>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-6"">
                        <h5>Trabajadores</h5>
                        <table class=""table"">
                            <thead style=""background: #DCD379 "">
                                <tr>
                                    <th>RPE</th>
                                    <th>Nombre</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>S2ID</td>
                                    <td>Prueba 1</td>
                                </tr>
                                <tr>
                                    <td>S233</td>
                                    <td>Prueba 2</td>
                         ");
            WriteLiteral(@"       </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class=""col-6"">
                        <h5>Participantes</h5>
                        <table class=""table"">
                            <thead style=""background: #DCD379 "">
                                <tr>
                                    <th>RPE</th>
                                    <th>Nombre</th>
                                    <th>Eliminar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>S2ID</td>
                                    <td>Prueba 1</td>
                                    <td><i class=""fas fa-trash""></i></td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </");
            WriteLiteral(@"div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-primary"">Save changes</button>
            </div>
        </div>
    </div>
</div>
<!-- no jalo jaja y fin-->


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 317 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <script>\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 321 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr.options.positionClass = \'toast-bottom-right\';\r\n                    toastr[\'");
#nullable restore
#line 323 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                       Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 323 "D:\INEEL\Clonado\SISST\Areas\Gestion\Views\ReunionesDeDifusion\Put.cshtml"
                                                   Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                }\r\n            });\r\n    </script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SISST.Areas.Gestion.Models.ModelosDeDifusion.VMIndex> Html { get; private set; }
    }
}
#pragma warning restore 1591