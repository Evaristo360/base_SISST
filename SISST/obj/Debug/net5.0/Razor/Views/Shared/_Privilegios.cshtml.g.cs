#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9164a7806c2b156bc5ec82541bc0ef2aac7e399d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Privilegios), @"mvc.1.0.view", @"/Views/Shared/_Privilegios.cshtml")]
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
#nullable restore
#line 2 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
using SISST.ViewModels.Privilegios;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9164a7806c2b156bc5ec82541bc0ef2aac7e399d", @"/Views/Shared/_Privilegios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c56b15d81227fa3fe2d997657fb56d023b35578", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Privilegios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SISST.ViewModels.Privilegios.VMPrivilegio>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
  
    string nombreTabla = "";
    string clase = "";
    if ((String)ViewBag.accion == "detalle" || (String)ViewBag.accion2 == "detalle") { nombreTabla = "tblPrivilegioModal"; }
    else { nombreTabla = "tblPrivilegio"; }

#line default
#line hidden
#nullable disable
            WriteLiteral("<table");
            BeginWriteAttribute("id", " id=\"", 338, "\"", 365, 1);
#nullable restore
#line 9 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
WriteAttributeValue("", 343, Html.Raw(nombreTabla), 343, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"table table-striped my-4 w-100 border-gray border dataTables-example\">\r\n");
            WriteLiteral("\r\n    <thead>\r\n        <tr>\r\n            <th style=\"display:none;\"></th>\r\n");
#nullable restore
#line 15 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
             if ((String)ViewBag.accion != "detalle" && (String)ViewBag.accion2 != "detalle")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <th class=""sorting_asc_disabled sorting_desc_disabled"">
                    <div class=""tooltip-demo"">
                        <button type=""button"" id=""selecTodosPrivilegios"" style=""cursor:pointer;"" data-toggle=""tooltip"" title=""Seleccionar los registros filtrados"" class=""btn btn-outline btn-default btn-xs desbloquearFormulario""><i class=""fa-1x mr-2 far fa-check-square""></i></button>
                        <button type=""button"" id=""deSelecTodosPrivilegios"" style=""cursor:pointer;"" data-toggle=""tooltip"" title=""Deseleccionar los registros filtrados"" class=""btn btn-outline btn-default btn-xs desbloquearFormulario""><i class=""fa-1x mr-2 far fa-square""></i></button>
                    </div>
                </th>
");
#nullable restore
#line 23 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
           Write(Html.DisplayNameFor(model => model.nombrePrivilegio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
           Write(Html.DisplayNameFor(model => model.url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
           Write(Html.DisplayNameFor(model => model.modulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
           Write(Html.DisplayNameFor(model => model.seccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 40 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
         foreach (var item in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td style=\"display:none;\">");
#nullable restore
#line 44 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
                                 Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 45 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
             if ((String)ViewBag.accion != "detalle" && (String)ViewBag.accion2 != "detalle")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n");
#nullable restore
#line 48 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
                      
                        Boolean marcado = false;
                        if ((List<VMPrivilegio>) ViewBag.listaUsuarioPrivilegios != null)
                        {
                            foreach (var itemPrivilegio in (List<VMPrivilegio>
                                )ViewBag.listaUsuarioPrivilegios)
                            {
                                if (item.id == itemPrivilegio.id)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <input type=\"checkbox\" name=\"enUsuario\"");
            BeginWriteAttribute("id", " id=\"", 2717, "\"", 2741, 2);
            WriteAttributeValue("", 2722, "privilegio_", 2722, 11, true);
#nullable restore
#line 57 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
WriteAttributeValue("", 2733, item.id, 2733, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"ckPrivilegio\" checked=\"checked\" />\r\n");
#nullable restore
#line 58 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
                                    marcado = true;
                                }
                            }
                            if (!marcado)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <input type=\"checkbox\" name=\"vacio\"");
            BeginWriteAttribute("id", " id=\"", 3046, "\"", 3070, 2);
            WriteAttributeValue("", 3051, "privilegio_", 3051, 11, true);
#nullable restore
#line 63 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
WriteAttributeValue("", 3062, item.id, 3062, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"ckPrivilegio\" />\r\n");
#nullable restore
#line 64 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
                            }
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"checkbox\" name=\"vacio\"");
            BeginWriteAttribute("id", " id=\"", 3275, "\"", 3299, 2);
            WriteAttributeValue("", 3280, "privilegio_", 3280, 11, true);
#nullable restore
#line 68 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
WriteAttributeValue("", 3291, item.id, 3291, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"ckPrivilegio\" />\r\n");
#nullable restore
#line 69 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n");
#nullable restore
#line 72 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>\r\n\r\n                ");
#nullable restore
#line 75 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
           Write(Html.DisplayFor(modelItem => item.nombrePrivilegio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n                ");
#nullable restore
#line 79 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
           Write(Html.DisplayFor(modelItem => item.url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 82 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
           Write(Html.DisplayFor(modelItem => item.modulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 85 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
           Write(Html.DisplayFor(modelItem => item.seccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 90 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_Privilegios.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SISST.ViewModels.Privilegios.VMPrivilegio>> Html { get; private set; }
    }
}
#pragma warning restore 1591