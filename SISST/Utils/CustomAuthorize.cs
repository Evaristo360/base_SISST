using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.Filters;
using SISST.ViewModels.Privilegios;
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Net;  
using System.Security.Claims;
using Microsoft.AspNetCore.Routing;
using System.Reflection.Metadata.Ecma335;
using SISST.ViewModels.Comunes.Roles;
using SISST.ViewModels.Comunes.Privilegios;

namespace SISST.Utils
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params string[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
    }

    public class AuthorizeFilter : IAuthorizationFilter
    {
        readonly string[] _claim;

        public AuthorizeFilter(params string[] claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            var userName = context.HttpContext.User.Identity.Name;
            var claimsIndentity = context.HttpContext.User.Identity as ClaimsIdentity;
            List<VMPrivilegioBase> listaPrivilegios = new List<VMPrivilegioBase>();
            if (IsAuthenticated)
            {
                if (string.IsNullOrEmpty(userName))
                {
                    context.Result = new RedirectResult("~/Home/NoAutenticado");
                }

                //Buscar privilegios del rol seleccionado
                bool tienePrivilegio = false;
                bool tieneRol = false;
                VMRolPrivilegioClaim rolActivo = null;
                List<string> rolesUsuario = new List<string>();

                var buscaPrivilegios = claimsIndentity.FindFirst("roles");
                if (buscaPrivilegios != null)
                {
                    List<VMRolPrivilegioClaim> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(buscaPrivilegios.Value); 
                    rolActivo = parametros.FirstOrDefault(x => x.Activo == true);
                    foreach(var r in parametros)
                    {
                        rolesUsuario.Add(r.Name);
                    }
                    listaPrivilegios =rolActivo== null ? new List<VMPrivilegioBase>() : rolActivo.Privilegios;                    
                }
                //buscar privilegios del usuario 
                var privilegiosUsuario = claimsIndentity.FindFirst("PrivilegiosUsuario");
                List<VMPrivilegioBase> privilegios = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMPrivilegioBase>>(privilegiosUsuario.Value);
                if(privilegios.Count>0)
                {
                    listaPrivilegios.AddRange(privilegios);
                }

                //VALIDAR PRIVILEGIO SOLICITADO
                var routeData = context.HttpContext.GetRouteData();
                var areaName = routeData?.Values["area"]?.ToString();
                var area = string.IsNullOrWhiteSpace(areaName) ? string.Empty : areaName;

                var controllerName = routeData?.Values["controller"]?.ToString();
                var controller = string.IsNullOrWhiteSpace(controllerName) ? string.Empty : controllerName;

                var actionName = routeData?.Values["action"]?.ToString();
                var action = string.IsNullOrWhiteSpace(actionName) ? string.Empty : actionName;

                if (verificaPrivilegio(controllerName, actionName, userName, listaPrivilegios))
                {
                    tienePrivilegio = true;
                }
                //SI NO SE RECIBE ROL, SE TOMARÁ COMO NO NECESARIO, NO SE REFIERE A ROL ACTIVO, SINO A LOS ROLES QUE TENGA EL USUARIO
                if ( _claim.Length>0 )
                {                    
                        foreach (var item in _claim)
                        {
                           if(rolesUsuario.Contains(item))
                                tieneRol = true;
                        }                    
                }
                

                if (tieneRol)
                {
                    //permitir aunque no sea el rol activo ni cuente con el privilegio, aplica para métodos especiales
                }
                else if (tienePrivilegio)
                {
                    //permitir acceso porque cuenta con el privilegio
                }
                else
                { 
                    //no tiene rol particular
                    //no tiene privilegio
                    //no se autoriza

                    //if (context.HttpContext.Request.IsAjaxRequest())
                    //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Set HTTP 401   
                    //else
                    if (area.Equals("GestionRL"))
                    {
                        context.Result = new RedirectResult($"~/Home/NoAutorizadoRL?ruta='/{controller}/{action}'");
                    }
                    else
                    {
                        context.Result = new RedirectResult("~/Home/NoAutorizado");
                    }
                }
            }
            else
            {                            
                    context.Result = new RedirectResult("~/Home/NoAutenticado");                
            }
            return;
        }


        /// <summary>
        /// Verifica si el usuario actual tiene asignado un privilegio
        /// </summary>
        /// <param name="controller">Controller en el cual se desencadena la acción</param>
        /// <param name="accion">Nombre del metodo que corresponde a la acción a realizar</param>
        /// <param name="userName">Nombre de usuario</param>
        /// <param name="privilegios">Lista de privilegios</param>
        /// <returns>True si el usuario tiene asignado el privilegio, de lo contrario False</returns>
        private bool verificaPrivilegio(string controller, string accion, string userName, List<VMPrivilegioBase> privilegios)
        {
            bool tienePrivilegio = false;

            //var usuario = db.Users.Find(id);
            String urlMap = "/" + controller.ToUpper() + "/" + accion.ToUpper();
            //String urlMapCrud = "/" + controller.ToUpper() + "/*";

            if (userName.Trim().ToLower().Substring(0,5) == "admin")
            {
                tienePrivilegio = true;
            }
            else
            {                     
                var tienePriv = privilegios.Where(x => x.url.Trim().ToUpper() == urlMap).FirstOrDefault();
                if (tienePriv != null)
                {
                    tienePrivilegio = true;
                }
            }

            return tienePrivilegio;
        }

    }
}