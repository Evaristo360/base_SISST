using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SISST.Proxies.Comunes;
using Comunes.Responses;
using SISST.ViewModels.Comunes.AreasAdministradas;
using SISST.ViewModels.Comunes.Roles;
using SISST.ViewModels.Comunes;
using Microsoft.AspNetCore.Authentication;
using SISST.Extensions;
using System.Security.Claims;
using SISST.Proxies;

namespace SISST.Areas.Comunes.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Comunes")]
    public class AreasAdministradasController : Controller
    {
        private readonly ILogger<AreasAdministradasController> _logger;
        private readonly IAreasAdministradasProxy _areasAdministradasProxy;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIdentityProxy _identityProxy;
        private readonly ICatalogoProxy _catalogoProxy;
        public bool HasInvalidAccess { get; set; }
        public string ReturnBaseUrl { get; set; }
        public AreasAdministradasController(
           ILogger<AreasAdministradasController> logger,
           IAreasAdministradasProxy areasAdministradasProxy, IHttpContextAccessor httpContextAccessor, IIdentityProxy identityProxy,
            ICatalogoProxy catalogoProxy)
        {

            _areasAdministradasProxy = areasAdministradasProxy;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _identityProxy = identityProxy;
            _catalogoProxy = catalogoProxy;
        }
        [Utils.Authorize("ADMIN")]
        public async Task<IActionResult> IndexAsync()
        {            
            string idUsuario = User.FindFirst("IdUsuario").Value;
            string roles = User.FindFirst("Roles").Value;
            List<VMRolPrivilegioClaim> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(roles);
            int idRol = parametros.FirstOrDefault(x => x.Activo == true).Id;
            var areas = await _areasAdministradasProxy.GetAllAsync(int.Parse(idUsuario), idRol);
            return View(areas);
        }

        [Utils.Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int idAreaCreate)
        {
            string idUsuario = User.FindFirst("IdUsuario").Value;
            string roles = User.FindFirst("Roles").Value;
            List<VMRolPrivilegioClaim> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(roles);
            int idRol = parametros.FirstOrDefault(x => x.Activo == true).Id;
            if (ModelState.IsValid)
            {
                VMAreaAdministrada vm = new VMAreaAdministrada();
                vm.IdArea = idAreaCreate;
                vm.IdUsuario = int.Parse(idUsuario);
                vm.IdRol = idRol;
                var request = await _areasAdministradasProxy.Create(vm);
                string resultado = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode)
                {
                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar registrar el centro de trabajo. " + content.Message;
                }
                else
                {
                    TempData["tipoMensaje"] = "success";
                    TempData["mensaje"] = "El centro de trabajo ha sido registrado exitosamente";
                    var usuarioLogin = new AuthenticationExtension().ObtieneUsuarioLogueado(HttpContext.User.Identity as ClaimsIdentity);
                    usuarioLogin.rolActivo = idRol;
                    usuarioLogin.AreaActiva = idAreaCreate;
                    IdentityAccesso autenticado = await _identityProxy.Login(usuarioLogin);
                    if (!autenticado.Succeeded)
                    {
                        TempData["tipoMensaje"] = "error";
                        TempData["mensaje"] = "Ha ocurrido un error al agregar el centro de trabajo. ";
                        return RedirectToAction("Index");
                    }

                    await RealizarLoginAsync(autenticado, usuarioLogin);
                }
            }
            return RedirectToAction("Index");
        }

        private async Task RealizarLoginAsync(IdentityAccesso autenticado, UsuarioLogin usuarioLogin)
        {
            
            var authProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow.AddHours(10)
            };
            ClaimsPrincipal claimsIdentity = await new AuthenticationExtension(_identityProxy, _catalogoProxy).RealizarLoginAsync(autenticado, usuarioLogin);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        [Utils.Authorize("ADMIN")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int idAreaDelete)
        {
            string idUsuario = User.FindFirst("IdUsuario").Value;
            string roles = User.FindFirst("Roles").Value;
            int idArea =  Int32.Parse(User.FindFirst("idArea").Value);
            List<VMRolPrivilegioClaim> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(roles);
            int idRol = parametros.FirstOrDefault(x => x.Activo == true).Id;
            var request = await _areasAdministradasProxy.Delete(int.Parse(idUsuario), idRol, idAreaDelete);
            if (request.IsSuccessStatusCode)
            {
                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El centro de trabajo ha sido eliminado exitosamente";
                var usuarioLogin = new AuthenticationExtension().ObtieneUsuarioLogueado(HttpContext.User.Identity as ClaimsIdentity);
                usuarioLogin.rolActivo = idRol;
                usuarioLogin.AreaActiva = idArea == idAreaDelete ? null : idArea;
                IdentityAccesso autenticado = await _identityProxy.Login(usuarioLogin);
                if (!autenticado.Succeeded)
                {
                    TempData["tipoMensaje"] = "error";
                    TempData["mensaje"] = "Ha ocurrido un error al eliminar el centro de trabajo. ";
                    return RedirectToAction("Index");
                }

                await RealizarLoginAsync(autenticado, usuarioLogin);
            }
            else
            {
                string resultado = await request.Content.ReadAsStringAsync();
                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                TempData["tipoMensaje"] = "failure";
                TempData["mensaje"] = "Ha ocurrido un error al intentar eliminar el centro de trabajo. " + content.Message;
            }
            return RedirectToAction("Index");
        }

        //Devuelve las AreasAdministradas
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<VMAreaAdministrada>>> GetAreasAdministradas()
        {            
            return await getAllAreasAdministradas();
        }

        private async Task<List<VMAreaAdministrada>> getAllAreasAdministradas()
        {
            string idUsuario = User.FindFirst("IdUsuario").Value;
            string roles = User.FindFirst("Roles").Value;
            List<VMRolPrivilegioClaim> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(roles);
            int idRol = parametros.FirstOrDefault(x => x.Activo == true).Id;
            var areas = await _areasAdministradasProxy.GetAllAsync(int.Parse(idUsuario), idRol);
            return areas;

        }
    }
}
