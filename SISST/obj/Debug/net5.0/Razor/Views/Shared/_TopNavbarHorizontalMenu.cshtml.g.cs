#pragma checksum "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5efcef3607364a72431be5dc077a2b5020994733"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TopNavbarHorizontalMenu), @"mvc.1.0.view", @"/Views/Shared/_TopNavbarHorizontalMenu.cshtml")]
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
#line 1 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
using SISST.ViewModels.Privilegios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
using SISST.ViewModels.Comunes.Usuarios;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5efcef3607364a72431be5dc077a2b5020994733", @"/Views/Shared/_TopNavbarHorizontalMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c56b15d81227fa3fe2d997657fb56d023b35578", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TopNavbarHorizontalMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("navbar-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("search.html"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
  
    List<VMPrivilegio> Model = new List<VMPrivilegio>();
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
     if (User.Identity.IsAuthenticated)
    {
        //var lista = new List<VMPrivilegio>();
        //var json = HttpContextAccessor.HttpContext.Session.GetString("_privilegios");
        //Dictionary<string, object> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
        //var listaPrivilegios = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMPrivilegio>>(parametros.First(x => x.Key == "model").Value.ToString());
        //if (listaPrivilegios.Count() > 0)
        //    lista.AddRange(listaPrivilegios);
        //var jsonRoles = HttpContextAccessor.HttpContext.Session.GetString("_roles");
        //Dictionary<string, object> parametros2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonRoles.ToString());
        //var listaRoles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMAplicationRol>>(parametros2.First(x => x.Key == "model").Value.ToString());
        //if (listaRoles.Count() > 0)
        //{
        //    foreach (var lr in listaRoles)
        //    {
        //        lista.AddRange(lr.rolPrivilegio);
        //    }
        //}
        //Model = lista.Distinct().ToList();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    
<nav class=""navbar topnavbar navbar-expand-lg navbar-light"">
<!-- START navbar header-->
<!-- END navbar header-->
<!-- START Nav wrapper-->
<div class=""navbar-collapse collapse"" id=""topnavbar"">

<ul class=""nav navbar-nav mr-auto flex-column flex-lg-row"">
    <li");
            BeginWriteAttribute("class", " class=\"", 1786, "\"", 1846, 3);
            WriteAttributeValue("", 1794, "nav-item", 1794, 8, true);
            WriteAttributeValue(" ", 1802, "dropdown", 1803, 9, true);
#nullable restore
#line 40 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
WriteAttributeValue(" ", 1811, Html.isActive(controller: "Home"), 1812, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <a class=\"nav-link\"");
            BeginWriteAttribute("href", " href=\"", 1877, "\"", 1929, 1);
#nullable restore
#line 41 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
WriteAttributeValue("", 1884, Url.Action("Index","Home",new { area = "" }), 1884, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Inicio</a>\r\n    </li>\r\n");
#nullable restore
#line 44 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
             if(User.Identity.IsAuthenticated)
            {
                string iconDefault = "fa-minus";
                string controlador = string.Empty;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <!-- START Left navbar-->\r\n");
#nullable restore
#line 49 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
             if (Model != null && Model.Count() > 0)
            {


                var moduloActual = "";
                var NombreMenu = "";


                foreach (var item in Model.Where(x => x.porOmision == true).OrderBy(e => e.modulo))
                {
                    int index = 0;
                    if (NombreMenu == "")
                    {
                        NombreMenu = item.modulo;
                        index = item.url.IndexOf(@"/") > 0 ? item.url.LastIndexOf(@"/") : 2;
                        controlador = !string.IsNullOrEmpty(item.url)  ? item.url.Substring(1, index - 1) : "";
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                   Write(Html.Raw("<li class='nav-item dropdown " + @Html.isActive(controller: controlador) + "'><a class='nav-link dropdown-toggle dropdown-toggle-nocaret' href='#dashboard' data-toggle='dropdown'>" + NombreMenu + "</a><div class='dropdown-menu animated fadeIn'>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                                                                                                                                                                                                                                                                                         
                        //moduloActual = item.modulo;
                        moduloActual = item.modulo;
                    }
                    else if (NombreMenu != item.modulo)
                    {
                        NombreMenu = item.modulo;
                        index = item.url.IndexOf(@"/") > 0 ? item.url.LastIndexOf(@"/") : 2;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                   Write(Html.Raw("</div></li>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                                                ;
                        controlador = !string.IsNullOrEmpty(item.url) ? item.url.Substring(1, index - 1) : "";
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                   Write(Html.Raw("<li class='nav-item dropdown " + @Html.isActive(controller: controlador) + "'><a class='nav-link dropdown-toggle dropdown-toggle-nocaret' href='#dashboard' data-toggle='dropdown'>" + NombreMenu + "</a><div class='dropdown-menu animated fadeIn'>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                                                                                                                                                                                                                                                                                                                
                        moduloActual = item.modulo;
                    }

                    index = item.url.IndexOf(@"/")>0 ? item.url.LastIndexOf(@"/") : 2;
                    //!string.IsNullOrEmpty(item.url) 
                    string icono = !string.IsNullOrEmpty(item.icono) ? item.icono : iconDefault;
                    controlador = !string.IsNullOrEmpty(item.url) ? item.url.Substring(1, index - 1) : "";
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
               Write(Html.Raw("<a class='dropdown-item " + @Html.isActive(controller: controlador) + "' href='#' onclick=\"getURL('" + item.url + "','" + item.area+"')\"><em class='fas " + icono  + "'></em>&nbsp;" + item.nombrePrivilegio + "</a>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                                                                                                                                                                                                                                                       ;

                } //endforeach
                if (moduloActual != "")
                { 

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
             Write(Html.Raw("</li>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                                    }

                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n\r\n");
            WriteLiteral("        <!-- END Left navbar-->\r\n        <!-- START Right Navbar-->\r\n        <ul class=\"navbar-nav flex-row\">\r\n            <!-- START lock screen-->\r\n            <li class=\"nav-item\">\r\n                <a class=\"nav-link\"");
            BeginWriteAttribute("href", " href=\"", 5066, "\"", 5118, 1);
#nullable restore
#line 99 "C:\Users\akwid\Desktop\base_SISST\SISST\Views\Shared\_TopNavbarHorizontalMenu.cshtml"
WriteAttributeValue("", 5073, Url.Action("Logout", "Home",new {area = ""}), 5073, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" title=""Lock screen"">
                    <em class=""icon-lock""></em>
                </a>
            </li>
            <!-- END lock screen-->
            <!-- Fullscreen (only desktops)-->
            <li class=""nav-item d-none d-md-block"">
                <a class=""nav-link"" href=""#"" data-toggle-fullscreen="""">
                    <em class=""fa fa-expand""></em>
                </a>
            </li>

            <!-- START Offsidebar button
            <li class=""nav-item"">
                <a class=""nav-link"" href=""#"" data-toggle-state=""offsidebar-open"" data-no-persist=""true"">
                    <em class=""icon-notebook""></em>
                </a>
            </li>
            <!-- END Offsidebar menu-->
        </ul>
        <!-- END Right Navbar-->
        </div>
        <!-- END Nav wrapper-->
        <!-- START Search form-->
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5efcef3607364a72431be5dc077a2b502099473315734", async() => {
                WriteLiteral(@"
            <div class=""form-group"">
                <input class=""form-control"" type=""text"" placeholder=""Type and hit enter ..."">
                <div class=""fa fa-times navbar-form-close"" data-search-dismiss=""""></div>
            </div>
            <button class=""d-none"" type=""submit"">Submit</button>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <!-- END Search form-->
        </nav>
        <!-- END Top Navbar-->

        <script type=""text/javascript"">
            function getURL(patronURL, area) {
                var path = location.pathname;
                //var alias = ""System.Configuration.ConfigurationManager.AppSettings[""sitioWebAliasIIS""]"";
                var alias = """";
                //var area = ""/Comunes""
                //alert(location.protocol + ""//"" + location.host + alias + area + patronURL)
                location.href = location.protocol + ""//"" + location.host + alias + ""/""+ area + patronURL;
            }
        </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591