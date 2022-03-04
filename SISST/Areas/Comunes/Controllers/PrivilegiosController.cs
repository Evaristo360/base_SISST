using System.Threading.Tasks;
using SISST.Proxies;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.ViewModels.Privilegios;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Linq;
using Comunes.Responses;
using Comunes.Enumerables;

namespace SISST.Areas.Comunes.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Comunes")]
    [Utils.Authorize]
    public class PrivilegiosController : Controller
    {
        private readonly ILogger<PrivilegiosController> _logger;
        private readonly IPrivilegiosProxy _privilegiosProxy;
        private readonly ICatalogoProxy _catalogoProxy;

        public bool HasInvalidAccess { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnBaseUrl { get; set; }

        public PrivilegiosController(
           ILogger<PrivilegiosController> logger,
           IPrivilegiosProxy privilegiosProxy,
           ICatalogoProxy catalogoProxy
       )
        {
            _privilegiosProxy = privilegiosProxy;
            _logger = logger;
            _catalogoProxy = catalogoProxy; 
        }

        public async Task<IActionResult> Index()
        {
            var privs = await _privilegiosProxy.GetAllAsync();
            return View(privs);
        }


        public async Task<IActionResult> Create()
        {            
            var privilegio = new VMPrivilegio();

            var modulos = await _catalogoProxy.GetOpciones((int)enumCatalogos.Modulosdelsistema, 0);
            var opciones = new List<SelectListItem>();
            foreach (var m in modulos.Where(x => x.Estado != 0).ToList())
            {
                opciones.Add(new SelectListItem { Text = m.Nombre, Value = m.Nombre });
            }

            privilegio.lstOpciones = opciones;
            
            var opcionesAreas = new List<SelectListItem>();
            var areasPortal = await _catalogoProxy.GetOpciones((int)enumCatalogos.Areasdelportal, 0);
            foreach (var m in areasPortal.Where(x => x.Estado != 0).ToList())
            {
                opcionesAreas.Add(new SelectListItem { Text = m.Nombre, Value = m.Nombre });
            }
            privilegio.lstAreas = opcionesAreas;

            privilegio.activo = true;
            return View(privilegio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( VMPrivilegio privilegio)
        {
            var modulos = await _catalogoProxy.GetOpciones((int)enumCatalogos.Modulosdelsistema, 0);
            
            var opciones = new List<SelectListItem>();
            foreach (var m in modulos.Where(x => x.Estado != 0).ToList())
            {
                opciones.Add(new SelectListItem { Text = m.Nombre, Value = m.Nombre });
            }

            privilegio.lstOpciones = opciones;

            
            var opcionesAreas = new List<SelectListItem>();
            var areasPortal = await _catalogoProxy.GetOpciones((int)enumCatalogos.Areasdelportal, 0);
            foreach (var m in modulos.Where(x => x.Estado != 0).ToList())
            {
                opcionesAreas.Add(new SelectListItem { Text = m.Nombre, Value = m.Nombre });
            }
            privilegio.lstAreas = opcionesAreas;

            if (ModelState.IsValid)
            {
                privilegio.activo = true;
                var request = await _privilegiosProxy.Create(privilegio);
                if (!request.IsSuccessStatusCode)
                {
                    string resultado = await request.Content.ReadAsStringAsync();
                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar registrar el privilegio. " + content.Message;
                    return View(privilegio);
                }
                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El privilegio ha sido registrado exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");                
            }
            return View(privilegio);
        }


        [HttpGet]
        public async Task<ActionResult> Details (int? id)
        {
            VMPrivilegio priv = new VMPrivilegio();
            if (id != null)
            {
                priv = await _privilegiosProxy.GetByIdAsync((int)id);

            }
            return View(priv);
        }

        
        public async Task<ActionResult> Edit(int? id)
        {
            var modulos = await _catalogoProxy.GetOpciones((int)enumCatalogos.Modulosdelsistema, 0);
            VMPrivilegio priv = new VMPrivilegio();
            var opciones = new List<SelectListItem>();
            foreach (var m in modulos.Where(x => x.Estado != 0).ToList())
            {
                opciones.Add(new SelectListItem { Text = m.Nombre, Value = m.Nombre });
            }

            

            
            var opcionesAreas = new List<SelectListItem>();
            var areasPortal = await _catalogoProxy.GetOpciones((int)enumCatalogos.Areasdelportal, 0);
            foreach (var m in areasPortal.Where(x => x.Estado != 0).ToList())
            {
                opcionesAreas.Add(new SelectListItem { Text = m.Nombre, Value = m.Nombre });
            }
            

            
            if (id == null)
            {
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = Utils.Comunes.mensajeNulo;
                return RedirectToAction("Index");
            }            
            if (id != null)
            {
                priv = await _privilegiosProxy.GetByIdAsync((int)id);
                if (priv.id <= 0)
                {
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = Utils.Comunes.mensajeNoEncontrado;
                    return RedirectToAction("Index");
                }
            }
            priv.lstOpciones = opciones;
            priv.lstAreas = opcionesAreas;
            return View(priv);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VMPrivilegio privilegio)
        {
            var modulos = await _catalogoProxy.GetOpciones((int)enumCatalogos.Modulosdelsistema, 0);
            
            var opciones = new List<SelectListItem>();
            foreach (var m in modulos.Where(x => x.Estado != 0).ToList())
            {
                opciones.Add(new SelectListItem { Text = m.Nombre, Value = m.Nombre });
            }

            privilegio.lstOpciones = opciones;

            
            var opcionesAreas = new List<SelectListItem>();
            var areasPortal = await _catalogoProxy.GetOpciones((int)enumCatalogos.Areasdelportal, 0);
            foreach (var m in modulos.Where(x => x.Estado != 0).ToList())
            {
                opcionesAreas.Add(new SelectListItem { Text = m.Nombre, Value = m.Nombre });
            }
            privilegio.lstAreas = opcionesAreas;

            if (ModelState.IsValid)
            {   
                var request = await _privilegiosProxy.Edit(privilegio.id, privilegio);
                if (!request.IsSuccessStatusCode)
                {
                    string resultado = await request.Content.ReadAsStringAsync();
                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar actualizar el privilegio. " + content.Message;
                    return View(privilegio);
                }
                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El privilegio ha sido actualizado exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
            }
            return View(privilegio);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]       
        public async Task<IActionResult> Delete(int id)
        {
            var privilegio = await _privilegiosProxy.GetByIdAsync((int)id);
            privilegio.activo = !privilegio.activo;
            var request = await _privilegiosProxy.Edit(privilegio.id, privilegio);
            if (!request.IsSuccessStatusCode)
            {
                string resultado = await request.Content.ReadAsStringAsync();
                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = "Ha ocurrido un error al intentar actualizar el privilegio. " + content.Message;
                return View(privilegio);
            }
            TempData["tipoMensaje"] = "success";
            TempData["mensaje"] = "El privilegio ha sido actualizado exitosamente";

            //var request = await _privilegiosProxy.Delete(id);
            //if (request.IsSuccessStatusCode)
            //{
            //    TempData["tipoMensaje"] = "success";
            //    TempData["mensaje"] = "El privilegio ha sido eliminado exitosamente";
            //}
            //else
            //{
            //    string resultado = await request.Content.ReadAsStringAsync();
            //    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
            //    TempData["tipoMensaje"] = "failure";
            //    TempData["mensaje"] = "Ha ocurrido un error al intentar eliminar el privilegio. " + content.Message;
            //}
            return RedirectToAction("Index");
        }




    }
}
