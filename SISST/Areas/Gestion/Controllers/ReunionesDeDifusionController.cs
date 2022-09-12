using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.Areas.Gestion.Models.ModelosDeDifusion;
using System.Collections.Generic;
using System.Threading.Tasks;
using SISST.Proxies.Comunes;

namespace SISST.Areas.Gestion.Controllers
{
    //Controlador para dar privilegios y se se comenta la de abajo evitamos los privilegios
    //[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Gestion")]
    //[Utils.Authorize] // Comentar temporalmente, para permitir trabajar sin permisos
    public class ReunionesDeDifusionController : Controller
    {
        private readonly ILogger<ReunionesDeDifusionController> _logger;
        private readonly IReunionesProxy _reunionesProxy;

        public ReunionesDeDifusionController
        (
            ILogger<ReunionesDeDifusionController> logger,
            IReunionesProxy reunionesProxy
           )
        {
            _reunionesProxy = reunionesProxy;
            _logger = logger;
        }

       //devuelve varios tipos de datos : vista, JSON, viewcomponent
        public async Task<IActionResult> Index()
        {
            //var VMIndex = new VMIndex();
            List<VMIndex> reuniones = await _reunionesProxy.GetAllasync();
         
            return View(reuniones);
        }

        //Create es el nombre de mi vista
        //Ejemplo si mi vista se llama ConsultaEjecuitiva
        // el metodo seria .....
        // public IActionResult ConsultaEjecutiva(){ return View(); }

        //sepa pero lo comente si o que banda
        public IActionResult Create()
        {

            VMIndex index = new VMIndex();

            return View(index);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VMIndex reuniones )
        {
            if (ModelState.IsValid)
            {
                var request = await _reunionesProxy.CreateReunion(reuniones);
                if (!request.IsSuccessStatusCode)
                {
                   // Mensajes("Ha ocurrido un error al intentar crear la reunion.", "warning", request);
                    return View(reuniones);
                }
                    // Mensajes("la reunion ha sido generado exitosamente", "success");
                    return RedirectToAction("Index", "ReunionesDeDifusion");
            }
            else
            {
                return View(reuniones);
            }
        }


        public IActionResult Put()
        {

            VMIndex index = new VMIndex();

            return View(index);
        }
        public IActionResult Consulta()
        {

            VMIndex index = new VMIndex();

            return View(index);
        }
        public IActionResult DocumentosCreate()
        {

            VMIndex index = new VMIndex();

            return View(index);
        }

        public IActionResult Wen()
        {

            VMIndex index = new VMIndex();

            return View(index);
        }
        #region mensajes nomasw de bverificacion o un pero asi

        //private async void Mensajes(string mensaje, string tipoMensaje, HttpResponseMessage request = null)
        //{
        //    TempData["tipoMensaje"] = tipoMensaje;
        //    TempData["mensaje"] = mensaje;
        //    if (request != null)
        //    {
        //        string resultado = await request.Content.ReadAsStringAsync();
        //        ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
        //        TempData["mensaje"] += content.Message;
        //    }
        //}
        #endregion

    }
}
