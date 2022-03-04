
using Comunes.Enumerables;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.Proxies;
using SISST.Utils;
using SISST.ViewModels.Comunes;
using SISST.ViewModels.Comunes.AreasAdministradas;
using SISST.ViewModels.Comunes.Privilegios;
using SISST.ViewModels.Comunes.Roles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace SISST.Extensions
{
    public class AuthenticationExtension
    {
        private const string passPhrase = "5155TT_V2";
        private readonly IIdentityProxy _identityProxy;
        private readonly ICatalogoProxy _catalogoProxy;

        public AuthenticationExtension(IIdentityProxy identityProxy, ICatalogoProxy catalogoProxy)
        {            
            _identityProxy = identityProxy;
            _catalogoProxy = catalogoProxy;
        }
        public AuthenticationExtension()
        {
        }


        public async Task<ClaimsPrincipal> RealizarLoginAsync(IdentityAccesso autenticado, UsuarioLogin usuarioLogin, string ip="",string host="")
        {
            var token = autenticado.TokenAcceso.Split('.');
            var base64Content = Convert.FromBase64String(token[1].PadRight(token[1].Length + (token[1].Length * 3) % 4, '='));

            var user = System.Text.Json.JsonSerializer.Deserialize<AccessTokenUserInformation>(base64Content);

            //guardar pwd encriptado en claim                    
            string encryptedPwd = string.Empty;
            try
            {
                encryptedPwd = Cipher.Encrypt(usuarioLogin.Password, passPhrase);
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }

            //Se cambia esto porque sale error HTTP Error 400. The size of the request headers is too long.
            int idUsuario = int.Parse(user.nameid);
            //se obtienen los roles que se trajeron en la autenticación
            List<VMRolPrivilegioClaim> roles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(user.Role);
            //Se obtienen los privilegios del rol activo
            VMRolPrivilegioClaim rolActivo = roles.FirstOrDefault(x => x.Activo == true);
            //se le agregan los privilegios a ese rol activo
            List<VMPrivilegioBase> privilegiosRol = new List<VMPrivilegioBase>();

            string rolActivoId = "";
            string PrioridadRol = "";
            string esAdmin = "";//se agregaron estas 2 validaciones porque truena cuando rolActivo es nulo
            List<SelectListItem> areasAdministradas = new List<SelectListItem>();
            if (rolActivo != null)
            {
                privilegiosRol = await _identityProxy.GetPrivilegiosByRol(rolActivo.Id);
                //rolActivo.Privilegios = privilegiosRol;
                rolActivoId = rolActivo.Id.ToString();
                //Se obtiene la Prioridad del rol Activo
                PrioridadRol = rolActivo.Prioridad.ToString();
                esAdmin = rolActivo.Name.ToLower().Equals("administrador") ? "1" : "0";
                var areasDelRol = await _identityProxy.GetAllAsync(idUsuario, rolActivo.Id);

                foreach (VMAreaAdministrada ar in areasDelRol)
                {
                    if (ar.IdJerarquico == rolActivo.IdNivelJerarquico || rolActivo.Prioridad == 5)
                    {
                        int areaLogin = int.Parse(user.IdArea);
                        if (ar.IdArea == areaLogin)
                            areasAdministradas.Add(new SelectListItem(ar.ClaveArea + " - " + ar.NombreArea, ar.IdArea.ToString(), true));
                        else
                            areasAdministradas.Add(new SelectListItem(ar.ClaveArea + " - " + ar.NombreArea, ar.IdArea.ToString(), false));
                    }
                }
                areasAdministradas.Add(new SelectListItem("Agregar", "0", false));
            }
            else
            {
                esAdmin = user.unique_name.ToLower().Equals("admin") ? "1" : "0"; //TODO: esto se debe de cambiar segun lo solicitado por angel 
            }

          
            //se obtienen privilegios directos
            List<VMPrivilegioBase> listaPrivilegios = await _identityProxy.GetPrivilegiosByUser(idUsuario);
           

            //Obtener módulos del sistema: No se obtienen porque API catálogos indica que no se tiene autorización
            var modulosSistema = await _catalogoProxy.GetOpciones((int)enumCatalogos.Modulosdelsistema, 0);
            var modulosDelSistema = new List<string>();
            if (modulosSistema == null || modulosSistema.Count() == 0)
            {
                modulosDelSistema.Add("Incidentes");
                modulosDelSistema.Add("Gestión de seguridad");
                modulosDelSistema.Add("Proyectos de seguridad");
                modulosDelSistema.Add("Protección civil integral");
                modulosDelSistema.Add("Panel de control");
            }
            else
            {
                foreach (var m in modulosSistema.Where(x => x.Estado != 0).OrderBy(x => x.Orden).ToList())
                {
                    modulosDelSistema.Add(m.Nombre);
                }
            }
            //Verificar si algún privilegio de la lista tiene restricción por proceso o por rol
            //para no agregarlo
            List<VMPrivilegioBase> listaFinalPrivilegiosRolActivo = new List<VMPrivilegioBase>();
            List<VMPrivilegioBase> listaFinalPrivilegiosUsuario = new List<VMPrivilegioBase>();            
            try
            {               
                foreach (var item in privilegiosRol)
                {
                    if(item.ListaOcultarParaIdProceso.Any(y=>y== int.Parse(user.IdProceso))==false && item.ListaOcultarParaIdRol.Any(z=>z==rolActivo.Id)==false)
                    {                     
                        listaFinalPrivilegiosRolActivo.Add(item);
                    }                    
                }                
            }
            catch(Exception e)
            {
                Debug.WriteLine("Excepción: " + e.Message);
            }
            var listToRemove3 = listaPrivilegios.Where(x => x.ListaOcultarParaIdProceso.Any(y => y == int.Parse(user.IdProceso)));
            var listToRemove4 = listaPrivilegios.Where(x => x.ListaOcultarParaIdRol.Any(y => y == rolActivo.Id));                    

            foreach (var item in listaPrivilegios)
            {
                bool existe3 = listToRemove3.Any(em => em.id == item.id);
                bool existe4 = listToRemove4.Any(em => em.id == item.id);
                if (!existe3 && !existe4)
                {
                    listaFinalPrivilegiosUsuario.Add(item);
                }
            }
            //asignar privilegios de rol activo
            if (rolActivo != null)
            {               
                rolActivo.Privilegios = listaFinalPrivilegiosRolActivo;
            }
                //Convertir privilegios a string
                string rolJson = Newtonsoft.Json.JsonConvert.SerializeObject(roles);
                string privilegiosVaciosJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaFinalPrivilegiosUsuario);
                //listaPrivilegios);

            //Agregar claims
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.nameid),
                        new Claim(ClaimTypes.Name, user.unique_name + " " + user.family_name),
                        new Claim(ClaimTypes.Email, user.email),
                        new Claim("access_token", autenticado.TokenAcceso),
                        new Claim("roles", rolJson),//user.Role), //Obtener prioridad del rolActivoId
                        new Claim("Prioridad", PrioridadRol),
                        new Claim("PrivilegiosUsuario", privilegiosVaciosJson),
                        new Claim("IdUsuario", user.nameid),
                        new Claim("IdTrabajador",user.IdTrabajador),
                        new Claim("IdArea", user.IdArea.ToString()),
                        new Claim("IdProceso", user.IdProceso.ToString()),
                        new Claim("ClaveArea", user.ClaveArea.ToString()),
                       // new Claim("RolActivo", rolActivo.Id.ToString()),
                        //new Claim("EsAdmin", rolActivo.Name.ToLower().Equals("admin")? "1": "0"), //SI ROLACTIVO ES NULL, TRUENA, SRC.
                        new Claim("RolActivo", rolActivoId),
                        new Claim("EsAdmin", esAdmin),
                        new Claim("Area", user.Area),
                        new Claim("rpe",usuarioLogin.RPE),
                        new Claim("key",encryptedPwd),
                        new Claim("modulosDelSistema",String.Join(", ",modulosDelSistema)),
                        new Claim("areasAdministradas", Newtonsoft.Json.JsonConvert.SerializeObject(areasAdministradas)),
                        new Claim("ip",ip),
                        new Claim("hostName",host)
                    };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow.AddHours(10)
            };

           return new ClaimsPrincipal(claimsIdentity);
        }

        public UsuarioLogin ObtieneUsuarioLogueado(ClaimsIdentity claimsIndentity)
        {
            var usuarioLogin = new UsuarioLogin();
            var RPE = claimsIndentity.FindFirst("rpe");
            //Recuperar pwd
            var encryptedPwd = claimsIndentity.FindFirst("key");
            string decripted = Cipher.Decrypt(encryptedPwd.Value, passPhrase);

            usuarioLogin.RPE = RPE.Value;
            usuarioLogin.Password = decripted;
            return usuarioLogin;
        }
    }
}
