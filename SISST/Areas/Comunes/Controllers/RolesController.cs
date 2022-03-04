using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SISST.Proxies;
using SISST.Proxies.Comunes;
using Comunes.Responses;
using SISST.ViewModels.Comunes.Roles;
using SISST.ViewModels.Privilegios;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.ViewModels.Comunes.Catalogos;
using Comunes.Enumerables;

namespace SISST.Areas.Comunes.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Comunes")]
    [Utils.Authorize("ADMIN")]
    public class RolesController : Controller
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRolesProxy _rolesProxy;
        private readonly IPrivilegiosProxy _privilegiosProxy;
        private readonly ICatalogoProxy _catalogosProxy;
        public bool HasInvalidAccess { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnBaseUrl { get; set; }

        public RolesController(
           ILogger<RolesController> logger,
           IRolesProxy rolesProxy, 
           IPrivilegiosProxy privilegiosProxy,
           ICatalogoProxy catalogosProxy
       )
        {
            _privilegiosProxy = privilegiosProxy;
            _rolesProxy = rolesProxy;
            _logger = logger;
            _catalogosProxy = catalogosProxy;
        }

        public async Task<IActionResult> Index()
        {
            var privs = await _rolesProxy.GetAllAsync();
            return View(privs);
        }

        private async Task<List<SelectListItem>> cargaCatalogosAsync(int id, int idProceso)
        {
            List<SelectListItem> listSelectItems = new List<SelectListItem>();
            List<VMOpcion> listOpciones = await _catalogosProxy.GetOpciones(id, idProceso);
            foreach (VMOpcion opc in listOpciones)
            {
                listSelectItems.Add(new SelectListItem { Text = opc.Nombre, Value = opc.IdCatalogo.ToString() });
            }
            return listSelectItems;
        }

        public async Task<IActionResult> CreateAsync()
        {
            var rol = new VMRol();
            int idProceso = int.Parse(User.FindFirst("IdProceso").Value);
            rol.listaPrivilegios = await _privilegiosProxy.GetAllAsync();
            rol.listaNivelJerarquico = await cargaCatalogosAsync((int)enumCatalogos.Niveljerarquico, idProceso);
            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VMRol rol)
        {
            
            if (ModelState.IsValid)
            {
                rol.activo = true;
                var request = await _rolesProxy.Create(rol);
                string resultado = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode)
                {

                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar registrar el rol. " + content.Message;
                    return View(rol);
                }
                VMRol respuesta = JsonConvert.DeserializeObject<VMRol>(resultado);
                string listaPrivilegios = HttpContext.Request.Form[key: "listaPrivilegios"].ToString();
                if (!listaPrivilegios.Equals(string.Empty))
                {
                    VMAddRemovePrivilegios addPrivilegios = new VMAddRemovePrivilegios();
                    addPrivilegios.ids = listaPrivilegios.Split(',').Select(Int32.Parse).ToList();
                    request = await _rolesProxy.AddPrivilegiosToRol(respuesta.id, addPrivilegios);
                    if (!request.IsSuccessStatusCode)
                    {
                        resultado = await request.Content.ReadAsStringAsync();
                        ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                        TempData["tipoMensaje"] = "warning";
                        TempData["mensaje"] = "Ha ocurrido un error al intentar registrar los privilegios al rol. " + content.Message;
                        return View(rol);
                    }
                }
                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El rol ha sido registrado exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                int idProceso = int.Parse(User.FindFirst("IdProceso").Value);
                rol.listaPrivilegios = await _privilegiosProxy.GetAllAsync();
                rol.listaNivelJerarquico = await cargaCatalogosAsync((int)enumCatalogos.Niveljerarquico, idProceso);

                ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
            }
            return View(rol);
        }


        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            VMRolDetalle priv = new VMRolDetalle();
            if (id != null)
            {
                priv = await _rolesProxy.GetByIdDetalleAsync((int)id);
                priv.listaPrivilegios = await _privilegiosProxy.GetPrivilegiosByRol((int)id);
            }
            return View(priv);
        }

       
        public async Task<ActionResult> Edit(int? id)
        {            
            VMRol rol = new VMRol();
            if (id == null)
            {
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = Utils.Comunes.mensajeNulo;
                return RedirectToAction("Index");
            }
            if (id != null)
            {                
                rol = await _rolesProxy.GetByIdAsync((int)id);
                rol.listaUsuarioPrivilegios = await _privilegiosProxy.GetPrivilegiosByRol((int)id);
                ViewBag.listaUsuarioPrivilegios = rol.listaUsuarioPrivilegios;


                int idProceso = int.Parse(User.FindFirst("IdProceso").Value);
                rol.listaPrivilegios = await _privilegiosProxy.GetAllAsync();
                rol.listaNivelJerarquico = await cargaCatalogosAsync((int)enumCatalogos.Niveljerarquico, idProceso);

                if (rol.id <= 0)
                {
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = Utils.Comunes.mensajeNoEncontrado;
                    return RedirectToAction("Index");
                }
            }
            return View(rol);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VMRol rol)
        {            
            List<VMPrivilegio> todosPrivilegios = await _privilegiosProxy.GetAllAsync();
            rol.listaUsuarioPrivilegios = await _privilegiosProxy.GetPrivilegiosByRol(rol.id);
            rol.listaPrivilegios = todosPrivilegios;
            int idProceso = int.Parse(User.FindFirst("IdProceso").Value);
            rol.listaNivelJerarquico = await cargaCatalogosAsync((int)enumCatalogos.Niveljerarquico, idProceso);

            if (ModelState.IsValid)
            {
                var request = await _rolesProxy.Edit(rol.id, rol);
                if (!request.IsSuccessStatusCode)
                {
                    string resultado = await request.Content.ReadAsStringAsync();
                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar actualizar el rol. " + content.Message;
                    return View(rol);
                }                
                string listaPrivilegios = HttpContext.Request.Form[key: "listaPrivilegios"].ToString();
                List<int> idsBorrar = todosPrivilegios.Select(x => x.id).ToList();
                VMAddRemovePrivilegios removePrivilegios = new VMAddRemovePrivilegios();
                //borrar todos
                removePrivilegios.ids = idsBorrar;
                request = await _rolesProxy.RemovePrivilegiosToRol(rol.id, removePrivilegios);
                if (!request.IsSuccessStatusCode)
                {
                    string resultado = await request.Content.ReadAsStringAsync();
                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar borrar los privilegios del rol. " + content.Message;
                    return View(rol);
                }
                if (!listaPrivilegios.Equals(string.Empty))
                {
                    VMAddRemovePrivilegios addPrivilegios = new VMAddRemovePrivilegios();
                    addPrivilegios.ids = listaPrivilegios.Split(',').Select(Int32.Parse).ToList();
                    ////elimino los q no estan seleccionados
                    //idsBorrar = todosPrivilegios.Where(x => !addPrivilegios.ids.Contains(x.id)).Select(x => x.id).ToList();
                    //removePrivilegios.ids = idsBorrar;
                    //request = await _rolesProxy.RemovePrivilegiosToRol(rol.id, removePrivilegios);
                    //if (!request.IsSuccessStatusCode)
                    //{
                    //    string resultado = await request.Content.ReadAsStringAsync();
                    //    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    //    TempData["tipoMensaje"] = "warning";
                    //    TempData["mensaje"] = "Ha ocurrido un error al intentar borrar los privilegios del rol. " + content.Message;
                    //    return View(rol);
                    //}
                    //agrego los seleccionados
                    request = await _rolesProxy.AddPrivilegiosToRol(rol.id, addPrivilegios);
                    if (!request.IsSuccessStatusCode)
                    {
                        string resultado = await request.Content.ReadAsStringAsync();
                        ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                        TempData["tipoMensaje"] = "warning";
                        TempData["mensaje"] = "Ha ocurrido un error al intentar registrar los privilegios al rol. " + content.Message;
                        return View(rol);
                    }
                }
                else
                {
                    //borrar todos
                    removePrivilegios.ids = idsBorrar;
                    request = await _rolesProxy.RemovePrivilegiosToRol(rol.id, removePrivilegios);
                    if (!request.IsSuccessStatusCode)
                    {
                        string resultado = await request.Content.ReadAsStringAsync();
                        ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                        TempData["tipoMensaje"] = "warning";
                        TempData["mensaje"] = "Ha ocurrido un error al intentar borrar los privilegios del rol. " + content.Message;
                        return View(rol);
                    }
                }
                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El rol ha sido actualizado exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                rol = await _rolesProxy.GetByIdAsync(rol.id);
                ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
            }
            
            return View(rol);
        }




        [HttpPost("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            VMRol rolse = await _rolesProxy.GetByIdAsync((int)id);
            rolse.activo = !rolse.activo;
            var request = await _rolesProxy.Edit(rolse.id, rolse);
            if (!request.IsSuccessStatusCode)
            {
                string resultado = await request.Content.ReadAsStringAsync();
                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = "Ha ocurrido un error al intentar actualizar el rol. " + content.Message;
                return View(rolse);
            }
            TempData["tipoMensaje"] = "success";
            TempData["mensaje"] = "El rol ha sido actualizado exitosamente";
            //var request = await _rolesProxy.Delete(id);
            //if (request.IsSuccessStatusCode)
            //{
            //    TempData["tipoMensaje"] = "success";
            //    TempData["mensaje"] = "El rol ha sido eliminado exitosamente";
            //}
            //else
            //{
            //    string resultado = await request.Content.ReadAsStringAsync();
            //    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
            //    TempData["tipoMensaje"] = "failure";
            //    TempData["mensaje"] = "Ha ocurrido un error al intentar eliminar el rol. " + content.Message;
            //}
            return RedirectToAction("Index");
        }




    }
}
