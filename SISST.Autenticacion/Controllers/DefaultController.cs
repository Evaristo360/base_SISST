using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SISST.Autenticacion.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/")]
    public class DefaultController : Controller
    {
        /// <summary>
        /// Indica que el servicio está en línea
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Index()
        {
            return "Los servicios de autenticación y de usuarios están en línea.";
        }
    }
}
