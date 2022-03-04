using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SISST.Catalog.Controllers
{
    
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet] 
        public string Index()
        {
            return "El servicio de catálogos está en línea ...";
        }
    }
}
