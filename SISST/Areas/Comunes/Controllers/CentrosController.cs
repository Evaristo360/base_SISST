using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunes.DTOs.pagination;
using Comunes.Enumerables;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SISST.Proxies;
using SISST.Proxies.Comunes;
using Comunes.Responses;
using SISST.ViewModels.Comunes.Areas;
using SISST.ViewModels.Comunes.Catalogos;
using SISST.ViewModels.Comunes.Roles;
using SISST.ViewModels.Pagination;
using dtoComunes = Comunes.DTOs;
namespace SISST.Areas.Comunes.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Comunes")]
    public class CentrosController : Controller
    {
        private readonly ILogger<CentrosController> _logger;
        private readonly IAreasProxy _areasProxy;
        private readonly ICatalogoProxy _catalogosProxy;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public bool HasInvalidAccess { get; set; }

        public CentrosController(
           ILogger<CentrosController> logger,
           IAreasProxy areasProxy, ICatalogoProxy catalogosProxy, IHttpContextAccessor httpContextAccessor)
        {

            _areasProxy = areasProxy;
            _logger = logger;
            _catalogosProxy = catalogosProxy;
            _httpContextAccessor = httpContextAccessor;
        }

        [Utils.Authorize("ADMIN")]
        public IActionResult IndexAsync()
        {
            //var areas = await _areasProxy.GetAllAsync();
            return View(); //areas
        }

        [Utils.Authorize("ADMIN")]
        public async Task<IActionResult> CreateAsync()
        {
            var area = new VMArea();
            area = await llenaCatalogosAsync(null, area);
            return View(area);
        }
        [Utils.Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VMArea vmarea)
        {

            if (ModelState.IsValid)
            {
                vmarea.Activo = true;
                var request = await _areasProxy.Create(vmarea);
                string resultado = await request.Content.ReadAsStringAsync();
                if (!request.IsSuccessStatusCode)
                {

                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar registrar el centro de trabajo. " + content.Message;
                    return View(vmarea);
                }

                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El centro de trabajo ha sido registrado exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                vmarea = await llenaCatalogosAsync(null, vmarea);
                vmarea = llenaAreas(vmarea);
                ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
            }
            return View(vmarea);
        }

        //Generico, Obtiene las opciones de un catalogo y las devuelve en un <List<SelectListItem>
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

        private async Task<VMArea> llenaCatalogosAsync(int? idArea, VMArea vmarea)
        {
            List<SelectListItem> listaAreas = new List<SelectListItem>();
            listaAreas.Add(new SelectListItem("Escriba el nombre o clave de la área a buscar", "0"));
            vmarea.listaAreas = listaAreas;
            vmarea.listaAreasTodas = await _areasProxy.GetAllExceptAsync(idArea);

            //se obtienen todos los catalogos a usar
            int idProceso = int.Parse(User.FindFirst("IdProceso").Value);
            vmarea.listaProcesos = await cargaCatalogosAsync((int)enumCatalogos.Procesos, idProceso);       
            vmarea.listaSubTipoInstalacion = new List<SelectListItem>();
            vmarea.listaNivelJerarquico = await cargaCatalogosAsync((int)enumCatalogos.Niveljerarquico, idProceso);
            vmarea.listaEntidadFederativa = await cargaCatalogosAsync((int)enumCatalogos.Entidadesfederativas, idProceso);
            vmarea.listaPrioridad = await cargaCatalogosAsync((int)enumCatalogos.PrioridadCentroTrabajo, idProceso);
            vmarea.listaMunicipio = new List<SelectListItem>();
            return vmarea;
        }

        [Utils.Authorize("ADMIN")]
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            VMAreaDetalle area = new VMAreaDetalle();
            if (id != null)
            {
                area = await _areasProxy.GetByIdDetalleAsync((int)id);

            }
            return View(area);
        }

        [Utils.Authorize("ADMIN")]
        public async Task<ActionResult> Edit(int? id)
        {
            VMArea area = new VMArea();
            if (id == null)
            {
                area = await llenaCatalogosAsync(id, area);
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = Utils.Comunes.mensajeNulo;
                return RedirectToAction("Index");
            }
            if (id != null)
            {
                area = await _areasProxy.GetByIdAsync((int)id);
                if (area.Id <= 0)
                {
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = Utils.Comunes.mensajeNoEncontrado;
                    return RedirectToAction("Index");
                }
                area = await llenaCatalogosAsync(id, area);
                area = llenaAreas(area);
            }
            return View(area);
        }

        private VMArea llenaAreas(VMArea area)
        {
            if (area.IdAreaSuperior != null)
            {
                List<SelectListItem> listaAreas = new List<SelectListItem>();
                listaAreas.Add(new SelectListItem(area.AreaSuperior, area.IdAreaSuperior.ToString(), true));
                area.listaAreasSuperior = listaAreas;
            }
            else
            {
                List<SelectListItem> listaAreas = new List<SelectListItem>();
                listaAreas.Add(new SelectListItem("Escriba el nombre o clave de la área a buscar", "0"));
                area.listaAreasSuperior = listaAreas;
            }
            if (area.IdAreaVerificacion != null)
            {
                List<SelectListItem> listaAreasVerificacion = new List<SelectListItem>();
                listaAreasVerificacion.Add(new SelectListItem(area.AreaVerificacion, area.IdAreaVerificacion.ToString(), true));
                area.listaAreasVerificacion = listaAreasVerificacion;
            }
            else
            {
                List<SelectListItem> listaAreasVerificacion = new List<SelectListItem>();
                listaAreasVerificacion.Add(new SelectListItem("Escriba el nombre o clave de la área a buscar", "0"));
                area.listaAreasVerificacion = listaAreasVerificacion;
            }
            return area;
        }

        [Utils.Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VMArea vmarea)
        {

            if (ModelState.IsValid)
            {
                var request = await _areasProxy.Edit(vmarea.Id, vmarea);
                if (!request.IsSuccessStatusCode)
                {
                    string resultado = await request.Content.ReadAsStringAsync();
                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "warning";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar actualizar el centro de trabajo. " + content.Message;
                    return View(vmarea);
                }

                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El centro de trabajo ha sido actualizado exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                vmarea = await llenaCatalogosAsync(vmarea.Id, vmarea);
                //vmarea = await _areasProxy.GetByIdAsync(vmarea.Id);
                vmarea = llenaAreas(vmarea);
                ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
            }

            return View(vmarea);
        }




        [Utils.Authorize("ADMIN")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vmarea = await _areasProxy.GetByIdAsync((int)id);
            vmarea.Activo = !vmarea.Activo;
            var request = await _areasProxy.Edit(vmarea.Id, vmarea);
            if (!request.IsSuccessStatusCode)
            {
                string resultado = await request.Content.ReadAsStringAsync();
                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = "Ha ocurrido un error al intentar actualizar el centro de trabajo. " + content.Message;
                return View(vmarea);
            }
            TempData["tipoMensaje"] = "success";
            TempData["mensaje"] = "El centro de trabajo ha sido actualizado exitosamente";
            //var request = await _areasProxy.Delete(id);
            //if (request.IsSuccessStatusCode)
            //{
            //    TempData["tipoMensaje"] = "success";
            //    TempData["mensaje"] = "El centro de trabajo ha sido eliminado exitosamente";
            //}
            //else
            //{
            //    string resultado = await request.Content.ReadAsStringAsync();
            //    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
            //    TempData["tipoMensaje"] = "failure";
            //    TempData["mensaje"] = "Ha ocurrido un error al intentar eliminar el centro de trabajo. " + content.Message;
            //}
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(string busqueda, int? id)
        {
            if (!string.IsNullOrEmpty(busqueda))
            {
                int idProceso = int.Parse(User.FindFirst("IdProceso").Value);
                var data = await _areasProxy.GetAllAreasBySearchAsync(busqueda, idProceso);
                if (id != null)
                {
                    data = data.Where(x => x.Id != id).ToList();
                }
                return Ok(data);
            }
            else
            {
                return Ok();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SearchAll(string busqueda, int? id)
        {
            if (!string.IsNullOrEmpty(busqueda))
            {
                int idProceso = 0;
                var data = await _areasProxy.GetAllAreasBySearchAsync(busqueda, idProceso);
                return Ok(data);
            }
            else
            {
                return Ok();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SearchOnlyCT(string busqueda, int? id)
        {
            if (!string.IsNullOrEmpty(busqueda))
            {
                var data = await _areasProxy.GetAllAreasBySearchOnlyCTAsync(busqueda, id);
                if (id != null)
                {
                    data = data.Where(x => x.Id != id).ToList();
                }
                return Ok(data);
            }
            else
            {
                return Ok();
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<VMOpcion>>> GetOpciones(int id)
        {
            List<VMOpcion> listOpciones = await _catalogosProxy.GetOpciones(id, 0);
            return listOpciones;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SearchByRolLvl(string busqueda)
        {
            if (!string.IsNullOrEmpty(busqueda))
            {

                int idProceso = int.Parse(User.FindFirst("IdProceso").Value);
                var roles = User.FindFirst("roles").Value;
                //se obtienen los roles que se almacenan en el claim
                var role = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(roles);
                //Se obtienen los privilegios del rol activo
                var rolData = role.FirstOrDefault(x => x.Activo == true);
                int idJerarquico = rolData.IdNivelJerarquico;
                var data = await _areasProxy.GetAllAreasSearchByRolLvlAsync(busqueda, idProceso, idJerarquico);
                return Ok(data);
            }
            else
            {
                return Ok();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        //Obtiene los centros por medio de Paginacion
        public async Task<IActionResult> GetAllPagination(VMPagination pagination)
        {
            pagination.hasFilter = true;
            ViewModels.Pagination.ResponsePagination<VMAreaDetalle> List_Trabajadores = await _areasProxy.GetAllPaginationAsync(pagination);
            return Json(List_Trabajadores);
        }

        [HttpGet]
        public async Task<ActionResult<List<VMAreaDetalle>>> getCTByAreaSuperior(int idAreaSuperior)
        {
            List<VMAreaDetalle> listCts = await _areasProxy.GetAllAreasChild(idAreaSuperior);
            return listCts;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<List<dtoComunes.CentroTrabajoSelectDto>> GetAllCentrosByIdList(string busqueda)
        {
            return await _areasProxy.GetAllCentrosByIdList(busqueda);
        }

    }
}
