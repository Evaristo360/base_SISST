#pragma checksum "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74e3f18513416c21c51e5ed8bfd239cca33f72ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Comunes_Views_AreasAdministradas_Index), @"mvc.1.0.view", @"/Areas/Comunes/Views/AreasAdministradas/Index.cshtml")]
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
#line 2 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
using SISST.ViewModels.Comunes.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74e3f18513416c21c51e5ed8bfd239cca33f72ea", @"/Areas/Comunes/Views/AreasAdministradas/Index.cshtml")]
    public class Areas_Comunes_Views_AreasAdministradas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SISST.ViewModels.Comunes.AreasAdministradas.VMAreaAdministrada>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/select2.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/datatable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/select2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/AreasAdministradas.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
   ViewData["Title"] = "Centros de trabajo administrados";
    Layout = "~/Views/Shared/_Layout.cshtml";
    string claseBotonGuardar = Context.Session.GetString("claseBotonGuardar");
    string IdArea = User.FindFirst("IdArea").Value;
    string lastUrl = Context.Request.Path;

    List<SelectListItem> listaAreas = new List<SelectListItem>();
    listaAreas.Add(new SelectListItem("Escriba el nombre o clave del centro de trabajo a buscar", ""));

    var roles = User.FindFirst("roles").Value;
    var prioridad = User.FindFirst("Prioridad").Value;
    //se obtienen los roles que se almacenan en el claim
    var role = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(roles);
    //Se obtienen los privilegios del rol activo
    var rolData = role.FirstOrDefault(x => x.Activo == true);
    int idJerarquico = rolData.IdNivelJerarquico;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card card-default\">\r\n    <div class=\"card-header\">\r\n        <div class=\"row\">\r\n            <div class=\"col-8\">\r\n                <h3 class=\"pl-3\">");
#nullable restore
#line 27 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                <ol class=""breadcrumb mb-0 "" style=""background-color:white;"">
                    <li class=""breadcrumb-item active"">
                        Lista de centros de trabajo administrados
                    </li>
                </ol>
            </div>
            <div class=""col-4 text-right mt-3"">
                <button class=""btn btn_sistema"" type=""button"" data-toggle=""modal"" data-target=""#mdlAreas"">Nuevo centro de trabajo administrado</button>
            </div>
        </div>
    </div>
</div>


<div class=""card card-default"">
    <div class=""card-body"">
        <table class=""table table-striped my-4 w-100 border-gray border"">
            <thead>

                <tr>
                    <th>
                        ");
#nullable restore
#line 49 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                   Write(Html.DisplayNameFor(r => r.ClaveArea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 52 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                   Write(Html.DisplayNameFor(r => r.NombreArea));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </th>
                    <th class=""text-center"">
                        Adscripción
                    </th>
                    <th class=""text-center"">
                        Administrar
                    </th>
                    <th>

                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 66 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 70 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => @item.ClaveArea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 73 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NombreArea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"text-center\">\r\n");
#nullable restore
#line 76 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                             if (item.EsPropietaria)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <i class=\"fas fa-star\" style=\"color:darkorange\" title=\"Centro de Adscripción\"></i>\r\n");
#nullable restore
#line 79 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td class=\"text-center\">\r\n");
#nullable restore
#line 82 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                             if (item.IdArea != int.Parse(IdArea))
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                                 if (idJerarquico == item.IdJerarquico || prioridad == "5")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 3516, "\"", 3651, 1);
#nullable restore
#line 86 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
WriteAttributeValue("", 3523, Url.Action("cambiaAreaActivo", "Home", new { Area = "", idArea = @item.IdArea, lastUrl = lastUrl, rol = rolData.Id.ToString()}), 3523, 128, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"Administrar Centro\" class=\"espereGuardar\"><i class=\"fas fa-sync-alt\"></i></a>\r\n");
#nullable restore
#line 87 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                                 
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <i class=\"fas fa-check-circle\" style=\"color:#4cff00;\" title=\"Centro Administrado\"></i>\r\n");
#nullable restore
#line 92 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 95 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                             if (!item.EsPropietaria)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a style=\"color:#656565\"");
            BeginWriteAttribute("href", " href=\"", 4224, "\"", 4264, 3);
            WriteAttributeValue("", 4231, "javascript:Eliminar(", 4231, 20, true);
#nullable restore
#line 97 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
WriteAttributeValue("", 4251, item.IdArea, 4251, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4263, ")", 4263, 1, true);
            EndWriteAttribute();
            WriteLiteral(" title=\"Eliminar\"><i class=\"far fa-trash-alt\"></i> </a>\r\n");
#nullable restore
#line 98 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 101 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 106 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
 using (Html.BeginForm("Delete", "AreasAdministradas", FormMethod.Post, new { @id = "frmDelete" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 109 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
Write(Html.Hidden("idAreaDelete", null, new { @id = "idAreaDelete" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 109 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                                                                    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 112 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
 using (Html.BeginForm("Create", "AreasAdministradas", FormMethod.Post, new { @id = "frmCreate" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 114 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
Write(Html.Hidden("idAreaCreate", null, new { @id = "idAreaCreate" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                                                                    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("BodyArea", async() => {
                WriteLiteral(@"
    <div class=""modal inmodal"" id=""mdlAreas"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
        <div class=""modal-dialog  modal-xl"">
            <div class=""modal-content animated fadeIn"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"">Agregar centros de trabajo administrados</h4>
                </div>
                <div id=""AreasParcial"" class=""modal-body modalArea"">
                    <div class=""form-group row"">
                        ");
#nullable restore
#line 127 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                   Write(Html.Label("CentroTrabajoLbl", "Centro de trabajo", htmlAttributes: new { @class = "col-md-2 offset-1 col-form-label " }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <div class=\"col-xl-9\">\r\n                            ");
#nullable restore
#line 129 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                       Write(Html.DropDownList("lstAreas", (IEnumerable<SelectListItem>
                            )listaAreas, "Seleccione...", new { @class = "form-control chosen-select", @id = "area" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                            <button class=""btn  btn-info"" type=""button"" onclick=""AgregarArea();"">Agregar</button>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-white desbloquearFormulario"" data-dismiss=""modal"">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "74e3f18513416c21c51e5ed8bfd239cca33f72ea17790", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "74e3f18513416c21c51e5ed8bfd239cca33f72ea18969", async() => {
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
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 150 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e3f18513416c21c51e5ed8bfd239cca33f72ea20563", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e3f18513416c21c51e5ed8bfd239cca33f72ea21663", async() => {
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
                WriteLiteral("\r\n    <script>\r\n            var urlAreaSearch = \'");
#nullable restore
#line 154 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                            Write(Url.Action("SearchByRolLvl", "Centros", new { Area = "Comunes" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n            $(document).ready(function () {\r\n                if (\'");
#nullable restore
#line 156 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' != \"\") {\r\n                    toastr.options.positionClass = \'toast-bottom-right\';\r\n                toastr[\'");
#nullable restore
#line 158 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                   Write(TempData["tipoMensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'](\'");
#nullable restore
#line 158 "D:\INEEL\Clonado\SISST\Areas\Comunes\Views\AreasAdministradas\Index.cshtml"
                                               Write(TempData["mensaje"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            }\r\n            });\r\n    </script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e3f18513416c21c51e5ed8bfd239cca33f72ea24124", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e3f18513416c21c51e5ed8bfd239cca33f72ea25224", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SISST.ViewModels.Comunes.AreasAdministradas.VMAreaAdministrada>> Html { get; private set; }
    }
}
#pragma warning restore 1591
