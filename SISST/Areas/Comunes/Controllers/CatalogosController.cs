using Comunes.Enumerables;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SISST.Proxies;
using Comunes.Responses;
using SISST.ViewModels.Comunes.Catalogos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SISST.Proxies.Comunes;


namespace SISST.Areas.Comunes.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Comunes")]
    [Utils.Authorize] // Comentar temporalmente, para permitir trabajar sin permisos
    public class CatalogosController : Controller
    {
        private readonly ILogger<CatalogosController> _logger;
        private readonly ICatalogoProxy _catalogoProxy;

        public CatalogosController(
            ILogger<CatalogosController> logger,
            ICatalogoProxy catalogoProxy
        )
        {
            _catalogoProxy = catalogoProxy;
            _logger = logger;
        }

        #region -->>    Sobre el catálogo
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("idCatalogo", "0"); // Se indica que no se tiene catálogo seleccionado
            List<VMCatalogo> catalogos = await _catalogoProxy.GetAll();
            return View(catalogos);
        }
        
        [HttpGet]        
        public async Task<ActionResult<List<VMOpcion>>> GetOpciones(int id)
        {
            List<VMOpcion> listOpciones = await _catalogoProxy.GetOpciones(id, 0);
            return listOpciones;
        }
        public async Task<IActionResult> Details(int id)
        {
            HttpContext.Session.SetString("idCatalogo", id.ToString()); //Se resguarda el identificador del catálogo
            VMCatalogoOpciones catalogo = await _catalogoProxy.GetCatalogoOpciones(id);
            return View(catalogo);
        }
        public IActionResult Create()
        {            
            ListaEstadosCatalogo();
            // Al crear la instancia se inicializan valores por omisión, en el constructor
            VMCatalogo catalogo = new VMCatalogo();
            
            return View(catalogo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VMCatalogo catalogo )
        {
            if (ModelState.IsValid)
            {
                var request = await _catalogoProxy.CreateCatalogo(catalogo);               
                if (!request.IsSuccessStatusCode)
                {
                    Mensajes("Ha ocurrido un error al intentar crear el catálogo.", "warning", request);
                    ListaEstadosCatalogo();// requerido para inicializar los estados
                    return View(catalogo);
                }
                Mensajes("El catálogo ha sido generado exitosamente", "success");
                return RedirectToAction("Index", null);
            }
            else
            {
                Mensajes("Los datos del catálogo no son consistentes.", "warning");
                ListaEstadosCatalogo();// requerido para inicializar los estados
                return View(catalogo);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            ListaEstadosCatalogo();

            VMCatalogo catalogo = await _catalogoProxy.GetCatalogo(id);
            return View(catalogo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VMCatalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                var request = await _catalogoProxy.UpdateCatalogo(catalogo);
                if (!request.IsSuccessStatusCode)
                {
                    Mensajes("Ha ocurrido un error al intentar actualizar el catálogo.", "warning", request);
                    ListaEstadosCatalogo();
                    return View(catalogo);
                }
                Mensajes("El catálogo ha sido actualizado exitosamente", "success");
                return RedirectToAction("Details", new { id = catalogo.IdCatalogo });
            }
            else
            {
               ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
            }
            return View(catalogo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(VMCatalogo catalogo)
        {
            var request = await _catalogoProxy.DeleteCatalogo(catalogo.IdCatalogo);
            if (request.IsSuccessStatusCode)
            {
                Mensajes("El catálogo ha sido eliminado exitosamente", "success");                
                return RedirectToAction("Index");
            }
            else
            {
                Mensajes("Ha ocurrido un error al intentar eliminar el catálogo.",  "warning", request );
                return RedirectToAction("Details", new { id = catalogo.IdCatalogo });
            }
        }
        #endregion

        #region -->>    Sobre las opciones
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador del catálago al cual pertenecerá la opción</param>
        /// <returns></returns>
        public async Task<IActionResult> CreateOpcion(int id)
        {
            ViewBag.IdCatalogo = HttpContext.Session.GetString("idCatalogo"); // Usada en el front End para redireccionar a la página anterior.
            await ListasEdicionOpciones(id);

            // Se obtiene el nombre del catálogo superior, para presentarlo en el front end.
            VMCatalogo catalogo = await _catalogoProxy.GetCatalogo(id);
            // Se inicializa la instancia, para registrar el Catálogo del cual depende la opción
            VMOpcion opcion = new VMOpcion();
            opcion.IdCatalogoSuperior = id;
            opcion.IdProceso = 0;
            opcion.EsSeleccionable = 1;
            opcion.NombreCatalogo = catalogo.Nombre;

            return View(opcion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOpcion(VMOpcion opcion)
        {
            ViewBag.IdCatalogo = HttpContext.Session.GetString("idCatalogo"); // Usada en el front End para redireccionar a la página anterior.
            int IdCatalogo = int.Parse(ViewBag.IdCatalogo);
            if (ModelState.IsValid)
            {
                if (opcion.EsSeleccionable.Equals(Byte.Parse("0")))
                    opcion.IdCatalogoSuperior = IdCatalogo;

                var request = await _catalogoProxy.CreateOpcion(opcion);
                if (!request.IsSuccessStatusCode)
                {
                    Mensajes("Ha ocurrido un error al intentar crear la opción.", "warning", request);
                    await ListasEdicionOpciones(IdCatalogo);
                    return View(opcion);
                }
                Mensajes("La opción sea a creado exitosamente.","success" );
                return RedirectToAction("Details", new { id = IdCatalogo });
            }
            else
            {
                Mensajes("Los datos de la opción no son consistentes.",  "warning");
                await ListasEdicionOpciones(IdCatalogo);
                return View(opcion); // Regresarla a la misma página
            }           
        }
        public async Task<IActionResult> DetailsOpcion(int id)
        {
            ViewBag.IdCatalogo = HttpContext.Session.GetString("idCatalogo"); ; // Usada en el front End para redireccionar a la página anterior.
            VMOpcion catalogo = await _catalogoProxy.GetOpcion(id);
            return View(catalogo);
        }
        public async Task<IActionResult> EditOpcion( int idOpcion )
        {
            ViewBag.IdCatalogo = HttpContext.Session.GetString("idCatalogo"); // Usada en el front End para redireccionar a la página anterior.

            await ListasEdicionOpciones(int.Parse(ViewBag.IdCatalogo));
            
            VMOpcion catalogo = await _catalogoProxy.GetOpcion(idOpcion);
            return View(catalogo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOpcion(VMOpcion opcion)
        {
            ViewBag.IdCatalogo = HttpContext.Session.GetString("idCatalogo"); // Usada en el front End para redireccionar a la página anterior.
            int IdCatalogo = int.Parse(ViewBag.IdCatalogo);
            if (ModelState.IsValid)
            {
                if (opcion.EsSeleccionable.Equals(Byte.Parse("0")))
                    opcion.IdCatalogoSuperior = IdCatalogo;

                var request = await _catalogoProxy.UpdateOpcion(opcion);
                if (!request.IsSuccessStatusCode)
                {
                    Mensajes("Ha ocurrido un error al intentar actualizar la opción del catálogo.", "warning", request);
                    await ListasEdicionOpciones(IdCatalogo);
                    return View(opcion);
                }
                Mensajes("La opción del catálogo ha sido actualizada exitosamente", "success" );
                return RedirectToAction("DetailsOpcion", new { id = opcion.IdCatalogo}); 
            }
            else
            {
                Mensajes("Hay valores incorrectos, revise los datos de la opción.", "warning");

                ModelState.AddModelError("", "Hay valores incorrectos, revise los datos de la opción.");
                await ListasEdicionOpciones(IdCatalogo);
                return View(opcion);
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOpcion(VMOpcion opcion)
        {
            int IdCatalogo = int.Parse( HttpContext.Session.GetString("idCatalogo"));
            var request = await _catalogoProxy.DeleteOpcion(opcion.IdCatalogo);
            if (request.IsSuccessStatusCode)
            {
                Mensajes("La opción de catálogo ha sido eliminada exitosamente", "success");
                return RedirectToAction("Details", new { id = IdCatalogo }); // Se regresa a los detalles del catálogo. 
            }
            else
            {
                Mensajes( "Ha ocurrido un error al intentar eliminar la opción del catálogo. ","warning", request );
                await ListasEdicionOpciones(IdCatalogo);
                return RedirectToAction("DetailsOpcion", new { id = opcion.IdCatalogo }); // Se regresa a los detalles de la opción. 
            }            
        }
        #endregion

        #region -->>    Varios métodos de apoyo, privados en la clase   <<--
        private void ListaEstadosOpcion()
        {
            List<SelectListItem> ListaEstados = new List<SelectListItem>()
            {
                new SelectListItem("Activo", "1"),
                new SelectListItem("Inactivo", "0")
             };
            ViewBag.ListaEstados = ListaEstados;
        }
        private void ListaEstadosCatalogo()
        {
            List<SelectListItem> ListaEstados = new List<SelectListItem>()
            {
                new SelectListItem("Activo", "1"),
                new SelectListItem("Inactivo", "0"),
                //new SelectListItem("Vinculado", "2"), Opci´pon solo para desarrollo, no habilitada para el ADM
             };
            ViewBag.ListaEstados = ListaEstados;
        }
        private void ListaProcesos(List<VMOpcion> procesos)
        {
            List<SelectListItem> ListaProcesos = new List<SelectListItem>()
            {
                new SelectListItem("Todos", "0")
            };
            foreach(VMOpcion proceso in procesos)
            {
                ListaProcesos.Add(new SelectListItem(proceso.Nombre, proceso.IdCatalogo.ToString()));
            }
            ViewBag.ListaProcesos = ListaProcesos;
        }
        /// <summary>
        /// Llena la lista de opciones Agrupadoras del catálogo (opciones con EsSeleccionable = 0)
        /// El valor "No aplica" es el valor del catálogo
        /// </summary>
        /// <param name="opcionesAgrupadoras"></param>
        /// <param name="idCatalogo"></param>
        private void ListaOpcionAgrupadora(List<VMCatalogo> opcionesAgrupadoras, int idCatalogo)
        {
            List<SelectListItem> ListaOpcionAgrupadora = new List<SelectListItem>()
            {
                new SelectListItem("No aplica", idCatalogo.ToString())
            };
            foreach (VMCatalogo opcion in opcionesAgrupadoras)
            {
                ListaOpcionAgrupadora.Add(new SelectListItem(opcion.Nombre, opcion.IdCatalogo.ToString()));
            }
            ViewBag.ListaOpcionAgrupadora = ListaOpcionAgrupadora;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCatalogo">Identificador del catálogo empleado para obtener las opciones agrupadoras.</param>
        /// <returns></returns>
        private async Task<Boolean> ListasEdicionOpciones(int idCatalogo)
        {
            // Para las listas de selección
            ListaEstadosOpcion();
            List<VMOpcion> procesos = await _catalogoProxy.GetOpciones((int)enumCatalogos.Procesos, 0);
            ListaProcesos(procesos);
            List<VMCatalogo> opcionesAgrupadoras = await _catalogoProxy.GetOpcionAgrupadora(idCatalogo);
            ListaOpcionAgrupadora(opcionesAgrupadoras, int.Parse(ViewBag.IdCatalogo));
            return true;
        }
        private async void Mensajes(string mensaje, string tipoMensaje, HttpResponseMessage request = null)
        {
            TempData["tipoMensaje"] = tipoMensaje;
            TempData["mensaje"] = mensaje;
            if (request != null)
            {
                string resultado = await request.Content.ReadAsStringAsync();
                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                TempData["mensaje"] += content.Message;
            }
        }
        #endregion
    }
}
