#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f3d365315db7cc46475d9318abf1e27649d4963"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__modalArea), @"mvc.1.0.view", @"/Views/Shared/_modalArea.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f3d365315db7cc46475d9318abf1e27649d4963", @"/Views/Shared/_modalArea.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c56b15d81227fa3fe2d997657fb56d023b35578", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__modalArea : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SISST.ViewModels.Comunes.Areas.VMAreaDetalle>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal inmodal"" id=""mdlAreas"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog  modal-lg"">
        <div class=""modal-content animated fadeIn"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Centros de trabajo</h4>
            </div>
            <div id=""AreasParcial"" class=""modal-body modalArea"">
                <table id=""tblAreas"" class=""table table-striped table-bordered table-hover dataTables-example"" style=""width:100%!important"">
                    <thead>

                        <tr>
                            <th>
                                ");
#nullable restore
#line 16 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
                           Write(Html.DisplayName("Clave"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 19 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
                           Write(Html.DisplayName("Nombre"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1185, "\"", 1258, 7);
            WriteAttributeValue("", 1192, "javascript:seleccionar(\'", 1192, 24, true);
#nullable restore
#line 28 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
WriteAttributeValue("", 1216, item.Id, 1216, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1224, "\',\'", 1224, 3, true);
#nullable restore
#line 28 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
WriteAttributeValue("", 1227, item.Clave, 1227, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1238, "--", 1239, 3, true);
#nullable restore
#line 28 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
WriteAttributeValue("  ", 1241, item.Nombre, 1243, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1255, "\');", 1255, 3, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 28 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
                                                                                                            Write(item.Clave);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 31 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_modalArea.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>

            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-white desbloquearFormulario"" data-dismiss=""modal"">Cerrar</button>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SISST.ViewModels.Comunes.Areas.VMAreaDetalle>> Html { get; private set; }
    }
}
#pragma warning restore 1591
