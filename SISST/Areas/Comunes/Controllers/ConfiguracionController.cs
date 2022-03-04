using Comunes.Responses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SISST.Proxies;
using SISST.ViewModels.Comunes.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SISST.Areas.Comunes.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Comunes")]
    public class ConfiguracionController : Controller
    {
        private readonly ILogger<ConfiguracionController> _logger;
        private readonly IConfiguracionProxy _configuracionProxy;

        public ConfiguracionController(
                ILogger<ConfiguracionController> logger,
                IConfiguracionProxy configuracionProxy
            )
        {
            _configuracionProxy = configuracionProxy;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<VMConfiguracion> configuraciones = await _configuracionProxy.GetConfiguraciones();
            return View(configuraciones);
        }
        public async Task<IActionResult> Details(int id)
        {
            VMConfiguracion configuracion = await _configuracionProxy.GetConfiguracion(id);
            return View(configuracion);
        }

        public  async Task<IActionResult> Edit(int id)
        {
            VMConfiguracion configuracion = new VMConfiguracion();
            if(!id.Equals(0))
                configuracion = await _configuracionProxy.GetConfiguracion(id);            
            return View(configuracion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VMConfiguracion configuracion)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage request;
                if (configuracion.Id.Equals(0))
                    request = await _configuracionProxy.Create(configuracion);
                else
                    request = await _configuracionProxy.Update(configuracion);

                if (!request.IsSuccessStatusCode)
                {
                    Mensajes("Ha ocurrido un error al intentar actualizar el registro de configuración.", "warning", request);
                    
                    return View(configuracion);
                }
                Mensajes("El registro de configuración ha sido actualizado exitosamente", "success");
                return RedirectToAction("Details", new { id = configuracion.Id });
            }
            else
            {
                ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
            }
            return View(configuracion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(VMConfiguracion configuracion)
        {
            var request = await _configuracionProxy.Delete(configuracion.Id);
            if (request.IsSuccessStatusCode)
            {
                Mensajes("El registro de configuración ha sido eliminado exitosamente", "success");
                return RedirectToAction("Index");
            }
            else
            {
                Mensajes("Ha ocurrido un error al intentar eliminar el registro de configuración .", "warning", request);
                return RedirectToAction("Details", new { id = configuracion.Id });
            }
        }


        public ActionResult Tipografia()
        {
            return View();
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
    }
}
