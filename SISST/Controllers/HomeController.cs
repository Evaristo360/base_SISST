using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.ViewModels.Comunes;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using SISST.Proxies;
using SISST.Proxies.Comunes;
using System.Linq;
using SISST.ViewModels.Comunes.Roles;
using System.Net;
using SISST.Utils;
using SISST.ViewModels.Privilegios;
using Microsoft.AspNetCore.Diagnostics;
using Comunes.Enumerables;
using SISST.ViewModels.Comunes.Privilegios;
using SISST.ViewModels.Comunes.AreasAdministradas;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.Extensions;

namespace SISST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIdentityProxy _identityProxy;
        private readonly IUsuarioProxy _usuariosProxy;
        private readonly ICatalogoProxy _catalogoProxy;
        private readonly IRolesProxy _rolesProxy;
        private readonly IAreasAdministradasProxy _areasAdministradasProxy;

        [BindProperty(SupportsGet = true)]
        public string ReturnBaseUrl { get; set; }

        private const string passPhrase = "5155TT_V2";
        public bool HasInvalidAccess { get; set; }

        public HomeController(
            ILogger<HomeController> logger,
            IIdentityProxy identityProxy,
            IUsuarioProxy usuariosProxy,
            IRolesProxy rolesProxy,
            ICatalogoProxy catalogoProxy,
            IAreasAdministradasProxy areasAdministradasProxy)
        {
            _logger = logger;
            _identityProxy = identityProxy;
            _usuariosProxy = usuariosProxy;
            _rolesProxy = rolesProxy;
            _catalogoProxy = catalogoProxy;
            _areasAdministradasProxy = areasAdministradasProxy;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UsuarioLogin usuarioLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityAccesso autenticado = await _identityProxy.Login(usuarioLogin);
                    if (!autenticado.Succeeded)
                    {
                        ModelState.AddModelError("Password", "El usuario y/o contraseña son incorrectos.");

                        HasInvalidAccess = true;
                        return View();
                    }
                    await RealizarLoginAsync(autenticado, usuarioLogin);

                    return RedirectToAction("Inicio", "Home", new { });

                }
            }
            catch (Exception e)
            {
                TempData["tipoMensaje"] = "error";
                TempData["mensaje"] = "Ha ocurrido un error. " + e.Message;
            }

            return View();
        }
        private async Task RealizarLoginAsync(IdentityAccesso autenticado, UsuarioLogin usuarioLogin)
        {
            var authProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow.AddHours(10)
            };
            //obtener ip y hostname para guardarlo en los claim
            string ipAddress = string.Empty;
            string host = string.Empty;
            try // try-catch temporal, mientras se resuelve que no se genere el mensaje: NO SUCH HOST KNOW!
            {
                IPAddress ip = Request.HttpContext.Connection.RemoteIpAddress;
                if (ip != null)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    {
                        ip = Dns.GetHostEntry(ip).AddressList.First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    }
                    ipAddress = ip.ToString();
                    host = Dns.GetHostEntry(ip).HostName;
                }
            }
            catch(Exception)
            {
                ipAddress = "0.0.0.0";
                host = "local";
            }
            //Si, es el primer Login se asigna por default el modulo de Incidentes
            if(usuarioLogin.AreaActiva == null && usuarioLogin.rolActivo == null)
            {
                HttpContext.Session.SetString("moduloSel", "Incidentes");
            }

            ClaimsPrincipal claimsIdentity = await new AuthenticationExtension(_identityProxy,_catalogoProxy).RealizarLoginAsync(autenticado, usuarioLogin, ipAddress, host);
            

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
        public async Task<IActionResult> cambiaRolActivo(int idRol)
        {
            //Cerrar sesión
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Relogin
            var usuarioLogin = new AuthenticationExtension().ObtieneUsuarioLogueado(HttpContext.User.Identity as ClaimsIdentity);
            usuarioLogin.rolActivo = idRol;

            IdentityAccesso autenticado = await _identityProxy.Login(usuarioLogin);
            if (!autenticado.Succeeded)
            {
                TempData["tipoMensaje"] = "error";
                TempData["mensaje"] = "Ha ocurrido un error al cambiar de rol activo. ";
                return RedirectToAction("Index", "Home", new { });
            }

            await RealizarLoginAsync(autenticado, usuarioLogin);

            //limpiar módulo activo
            HttpContext.Session.SetString("moduloSel", "Incidentes");

            return RedirectToAction("Inicio", "Home", new { });
        }
        public async Task<IActionResult> cambiaAreaActivo(int idArea, string lastUrl, int rol)
        {
            // 0     1       2       3          4 
            // ""  /Home/Inicio
            // ""  /Comunes/Usuarios/Index
            // ""  /Comunes/Usuarios/Details/1
            var partsUrl = lastUrl.Split("/");
            var action = "";
            var controller = "";
            var area = "";
            var id = partsUrl.Length > 4 ? partsUrl[4] : "";
            if (partsUrl.Length > 3)
            {
                action = partsUrl[3];
                controller = partsUrl[2];
                area = partsUrl[1];
            }
            else
            {
                action = partsUrl[2];
                controller = partsUrl[1];
            }

            //Cerrar sesión
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Relogin
            var usuarioLogin = new AuthenticationExtension().ObtieneUsuarioLogueado(HttpContext.User.Identity as ClaimsIdentity);
            usuarioLogin.AreaActiva = idArea;//AreaAdministrada Seleccionado
            usuarioLogin.rolActivo = rol;//se asigna el rol Activo
            IdentityAccesso autenticado = await _identityProxy.Login(usuarioLogin);
            if (!autenticado.Succeeded)
            {
                TempData["tipoMensaje"] = "error";
                TempData["mensaje"] = "Ha ocurrido un error al cambiar de centro de trabajo activo. ";
                return RedirectToAction("Index", "Home", new { });
            }
            await RealizarLoginAsync(autenticado, usuarioLogin);

            if (area.Equals("Diagnostico") && rol.Equals((int)enumRol.RSR))
                // Redirección para el módulo DIPCI para el usuario regional
                return RedirectToAction("Index", "ConfiguracionRegional", new { Area = area });
            else if (area.Equals("Diagnostico") )
                // Redirección para el módulo DIPCI para el usuario distinto a regional.
                return RedirectToAction("Index", "Evaluacion", new { Area = area });

            else if (action.Equals("Listado") || action.Equals("sinlesion") || action.Equals("IncidenteDeterioroSalud") || action.Equals("IncidenteContratista") || action.Equals("DanioEquipoMaterial")) {
                // Redirección para el módulo incidentes
                return RedirectToAction("Inicio", "Home", new { });
            } 

            else {
                return RedirectToAction(action, controller, new { Area = area, id = id }); 
            }
        }
        public IActionResult Register()
        {
            UsuarioInfo usuarioInfo = new UsuarioInfo();
            return View(usuarioInfo);
        }
        public IActionResult NoAutorizado()
        {
            return View();
        }
        public IActionResult NoAutenticado()
        {
            return View();
        }

        [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InicioAsync()
        {
            var claimsIndentity = User.Identity as ClaimsIdentity;
            VMRolPrivilegioClaim rolActivo = null;
            var model = new VMRol();
            var buscaPrivilegios = claimsIndentity.FindFirst("roles");
            if (buscaPrivilegios != null)
            {
                List<VMRolPrivilegioClaim> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(buscaPrivilegios.Value);
                rolActivo = parametros.FirstOrDefault(x => x.Activo == true);
                if (rolActivo != null)
                {
                    model.id = rolActivo.Id;
                    model.Name = rolActivo.Name;
                    model.descripcion = rolActivo.Descripcion;
                    model.activo = rolActivo.Activo;
                }
            }
            return View("InicioGenerico", model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsuarioInfo usuarioInfo)
        {
            if (ModelState.IsValid)
            {
                usuarioInfo.IdArea = "1";

                var request = await _identityProxy.Register(usuarioInfo);
                if (!request.IsSuccessStatusCode)
                {
                    HasInvalidAccess = true;
                    return View();
                }

                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ActionResult setModulo(string modulo)
        {

            if (string.IsNullOrEmpty(modulo))
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            else
            {
                HttpContext.Session.SetString("moduloSel", modulo);
                return StatusCode((int)HttpStatusCode.OK);
            }
        }
        public IActionResult NoAutorizadoRL(string ruta)
        {
            ViewData["ruta"] = ruta;
            return View();
        }
    }
}
