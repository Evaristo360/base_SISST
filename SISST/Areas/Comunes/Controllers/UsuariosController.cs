using System.Threading.Tasks;
using SISST.Proxies;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Comunes.Responses;
using System.Collections.Generic;
using SISST.ViewModels.Comunes.Usuarios;
using Newtonsoft.Json;
using SISST.Proxies.Comunes;
using System;
using System.Linq;
using SISST.ViewModels.Privilegios;
using SISST.ViewModels.Comunes.Roles;
using SISST.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.ViewModels.Comunes.Trabajadores;
using SISST.ViewModels.Pagination;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using SISST.Comunes.AspPdf;

namespace SISST.Areas.Comunes.Usuarios.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Comunes")]
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuarioProxy _usuarioProxy;
        private readonly IRolesProxy _rolesProxy;
        private readonly IPrivilegiosProxy _privilegiosProxy;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _hostEnvironment;

        public bool HasInvalidAccess { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnBaseUrl { get; set; }

        public List<VMPrivilegio> ListaPriv = new List<VMPrivilegio>();
        public UsuariosController(
            ILogger<UsuariosController> logger,
            IUsuarioProxy usuarioProxy, IRolesProxy rolesProxy, IPrivilegiosProxy privilegiosProxy, 
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostEnvironment
        )
        {
            _usuarioProxy = usuarioProxy;
            _rolesProxy = rolesProxy;
            _privilegiosProxy = privilegiosProxy;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _hostEnvironment = hostEnvironment;
        }


        [Authorize("ADMIN")]
        // GET: USuariosController        
        public async Task<IActionResult> Index()
        {

            //DataCollection<UsuarioDTO> Orders = await _usuarioProxy.GetAllAsync(CurrentPage, 10);
            List<VMUsuario> Orders = await _usuarioProxy.GetAllAsync(false);

            //List<VMAplicationRol> listaRoles = new List<VMAplicationRol>();
            //var privilegios = _servicios.getPrivilegiosUsuario(out listaRoles);
            //ViewBag.listaPrivilegios = privilegios;

            return View(Orders);
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost]
        //Obtiene los trabajadores por medio de Paginacion
        public async Task<IActionResult> GetAllPagination(VMPagination pagination)
        {
            ResponsePagination<VMUsuario> List_Usuarios = await _usuarioProxy.GetAllPaginationAsync(pagination);
            return Json(List_Usuarios);
        }


        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost]
        //Obtiene los trabajadores por medio de Paginacion
        public async Task<IActionResult> GetUsersbyRol(int idRol = 0, string search = "")
        {
            List<VMUsuario> List_Usuarios = await _usuarioProxy.GetUsersbyRol(idRol, search);
            return Json(List_Usuarios);
        }

        // GET: USuariosController/Create
        [Authorize("ADMIN")]
        public async Task<ActionResult> CreateAsync()
        {
            VMUsuario user = new VMUsuario();

            //user.IsAdmin
            user = await llenarDatosCreate(user);
            var esAdmin = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("EsAdmin", StringComparison.OrdinalIgnoreCase))?.Value;
            if (esAdmin.Equals("1"))
            {
                user.IsAdmin = true;
            }
            else
            {
                user.IsAdmin = false;
            }
            return View(user);
        }
        
        private async Task<VMUsuario> llenarDatosCreate(VMUsuario usuario)
        {
            List<SelectListItem> listatrabajadores = new List<SelectListItem>();
            if (usuario!= null && usuario.IdTrabajador != 0)
            {
                listatrabajadores.Add(new SelectListItem(usuario.RPE, usuario.IdTrabajador.ToString()));
            }
            else
            {
                listatrabajadores.Add(new SelectListItem("Escriba el nombre o RPE del trabajador a buscar", ""));
            }

            usuario.listatrabajadores = listatrabajadores;


            List<VMTrabajadorDetalle> trabajadoresModal = new List<VMTrabajadorDetalle>();// await _trabajadoresProxy.GetAllAsync();
            usuario.listatrabajadoresModal = trabajadoresModal;
            List<VMPrivilegio> privilegios = await _privilegiosProxy.GetAllAsync();
            //se obtiene el rol con el que se está trabajando para ver cuales puede ingresar basandose en la prioridad
            string roles = User.FindFirst("Roles").Value;
            List<VMRolPrivilegioClaim> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(roles);
            int prioridad = 0;
            if (parametros.FirstOrDefault(x => x.Activo == true) != null)
            {
                prioridad = parametros.FirstOrDefault(x => x.Activo == true).Prioridad;
            }

            usuario.listaPrivilegios = privilegios.Where(a=>a.activo).ToList();
            List<VMRol> rolesApi = await _rolesProxy.GetAllAsync();
            List<VMAplicationRol> listaRoles = new List<VMAplicationRol>();
            foreach (VMRol rolApi in rolesApi.Where(x=>x.activo /* && x.prioridad < prioridad */ ))
            {
                VMAplicationRol rolUsuario = new VMAplicationRol();
                rolUsuario.Id = rolApi.id;
                rolUsuario.Name = rolApi.Name;
                rolUsuario.descripcion = rolApi.descripcion;
                rolUsuario.rolPrivilegio = await _privilegiosProxy.GetPrivilegiosByRol(rolApi.id);
                if( rolApi.prioridad < prioridad )
                {
                    rolUsuario.esInvisible = false;
                }
                else
                {
                    rolUsuario.esInvisible = true;
                }
                listaRoles.Add(rolUsuario);
            }
            usuario.listaRoles = listaRoles;
            usuario.accion = "crear";
            return usuario;
        }

        // POST: USuariosController/Create
        [Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VMUsuario usuario)
        {
            var claveArea = HttpContext.Request.Form[key: "claveAreaNombre"].ToString();
            //usuario.Area = "";
            try
            {
                usuario.Area = claveArea.Split("--")[1].Trim();
            }
            catch( Exception ex) { }
            try
            {
                usuario.ClaveArea = claveArea.Split("--")[0].Trim();
            }
            catch (Exception ex) { }
            var esAdmin = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("EsAdmin", StringComparison.OrdinalIgnoreCase))?.Value;
            if (esAdmin.Equals("1"))
            {
                usuario.IsAdmin = true;
            }
            else
            {
                usuario.IsAdmin = false;
            }
            /* Verifica total de Roles */
            string listaRol = HttpContext.Request.Form[key: "listaRol"].ToString();
            if (listaRol.Equals(string.Empty))
            {
                //TempData["tipoMensaje"] = "warning";
                //TempData["mensaje"] = "Seleccionar al menos un rol. ";
                usuario = await llenarDatosCreate(usuario);
                ModelState.AddModelError("", "Seleccionar al menos un rol.");

            }
            else
            {
                if (ModelState.IsValid)
                {
                    usuario.RPE = usuario.RPE.Split(" -- ")[0];//obtener de RPE de la cadena RPE -- NombreClave

                    string idUsuario = User.FindFirst("IdUsuario").Value;
                    usuario.UserName = usuario.RPE;
                    usuario.userId = int.Parse(idUsuario);
                    usuario.Password = usuario.RPE;
                    var request = await _usuarioProxy.Create(usuario);
                    string resultado = await request.Content.ReadAsStringAsync();
                    if (!request.IsSuccessStatusCode)
                    {
                        ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                        TempData["tipoMensaje"] = "warning";
                        TempData["mensaje"] = "Ha ocurrido un error al intentar registrar el usuario. " + content.Message;
                        await llenarDatosCreate(usuario);
                        return View(usuario);
                    }
                    VMUsuario respuesta = JsonConvert.DeserializeObject<VMUsuario>(resultado);
                    //si todo salió bien se insertan roles y privilegios
                    //listaRol = HttpContext.Request.Form[key: "listaRol"].ToString();
                    if (!listaRol.Equals(string.Empty))
                    {
                        VMAddRemovePrivilegios addRoles = new VMAddRemovePrivilegios();
                        addRoles.ids = listaRol.Split(',').Select(int.Parse).ToList();
                        request = await _usuarioProxy.AddRoles(respuesta.Id, addRoles);
                        if (!request.IsSuccessStatusCode)
                        {
                            resultado = await request.Content.ReadAsStringAsync();
                            ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                            TempData["tipoMensaje"] = "warning";
                            TempData["mensaje"] = "Ha ocurrido un error al intentar registrar los roles al usuario. " + content.Message;
                            return View(usuario);
                        }

                    }
                    //Sólo un usuario Administrador logueado puede agregar los privilegios
                    if (usuario.IsAdmin)
                    {
                        string listaPrivilegios = HttpContext.Request.Form[key: "listaPrivilegios"].ToString();
                        if (!listaPrivilegios.Equals(string.Empty))
                        {
                            VMAddRemovePrivilegios addPrivilegios = new VMAddRemovePrivilegios();
                            addPrivilegios.ids = listaPrivilegios.Split(',').Select(int.Parse).ToList();
                            request = await _usuarioProxy.AddPrivilegios(respuesta.Id, addPrivilegios);
                            if (!request.IsSuccessStatusCode)
                            {
                                resultado = await request.Content.ReadAsStringAsync();
                                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                                TempData["tipoMensaje"] = "warning";
                                TempData["mensaje"] = "Ha ocurrido un error al intentar registrar los privilegios al usuario. " + content.Message;
                                return View(usuario);
                            }
                        }
                    }
                    TempData["tipoMensaje"] = "success";
                    TempData["mensaje"] = "El usuario ha sido registrado exitosamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    usuario = await llenarDatosCreate(usuario);
                    ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
                }
            }
            return View(usuario);
        }

        [Authorize("ADMIN")]
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            VMUsuario user = new VMUsuario();
            if (id == null)
            {
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = Utils.Comunes.mensajeNulo;
                return RedirectToAction("Index");
            }
            if (id != null)
            {
                user = await _usuarioProxy.GetByIdAsync((int)id);
                user = await llenarDatosDetalle(user);                
            }
            var esAdmin = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("EsAdmin", StringComparison.OrdinalIgnoreCase))?.Value;
            if (esAdmin.Equals("1"))
            {
                user.IsAdmin = true;
            }
            else
            {
                user.IsAdmin = false;
            }
            return View(user);
        }

        private async Task<VMUsuario> llenarDatosDetalle(VMUsuario usuario)
        {
            List<VMPrivilegio> lstPrivilegios = new List<VMPrivilegio>();
            
            List<SISST.ViewModels.Comunes.Roles.VMRol> rolesApi = await _usuarioProxy.GetRolesByUser(usuario.Id); //TODO: Obtener solo los del usuario
            List<VMAplicationRol> listaRoles = new List<VMAplicationRol>();
            foreach (SISST.ViewModels.Comunes.Roles.VMRol rolApi in rolesApi)
            {
                VMAplicationRol rolUsuario = new VMAplicationRol();
                rolUsuario.Id = rolApi.id;
                rolUsuario.Name = rolApi.Name;
                rolUsuario.descripcion = rolApi.descripcion;
                List<VMPrivilegio> listaPrivilegiosRol = await _privilegiosProxy.GetPrivilegiosByRol(rolApi.id);
                rolUsuario.rolPrivilegio = listaPrivilegiosRol;
                listaRoles.Add(rolUsuario);
                lstPrivilegios.AddRange(listaPrivilegiosRol);
            }
            lstPrivilegios.AddRange(await _privilegiosProxy.GetPrivilegiosByUser(usuario.Id));
            usuario.listaPrivilegios = lstPrivilegios;
            usuario.listaRoles = listaRoles;
            usuario.accion = "detalle";
            return usuario;
        }

        [Authorize("ADMIN")]
        // GET: USuariosController/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            VMUsuario user = new VMUsuario();
            if (id == null)
            {
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = Utils.Comunes.mensajeNulo;
                return RedirectToAction("Index");
            }
            if (id != null)
            {
                user = await _usuarioProxy.GetByIdAsync((int)id);
                
                await llenarDatosCreate(user);
                await llenarDatosEditar(user);
            }
            var esAdmin = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("EsAdmin", StringComparison.OrdinalIgnoreCase))?.Value;
            if (esAdmin.Equals("1"))
            {
                user.IsAdmin = true;
            }
            else
            {
                user.IsAdmin = false;
            }
            return View(user);
        }

        private async Task<VMUsuario> llenarDatosEditar(VMUsuario usuario)
        {
            //se obtienen los privilegios del usuario q no tienen q ver con algun rol
            usuario.listaUsuarioPrivilegios = await _privilegiosProxy.GetPrivilegiosByUser(usuario.Id);
            List<VMRol> listaUsuarioRol = await _usuarioProxy.GetRolesByUser(usuario.Id);
            List<VMRolPrivilegio> listaUsuarioRolPriv = new List<VMRolPrivilegio>();
            foreach (VMRol rolUsuario in listaUsuarioRol)
            {

                List<VMPrivilegio> listaPriv = await _privilegiosProxy.GetPrivilegiosByRol(rolUsuario.id);
                foreach (VMPrivilegio privi in listaPriv)
                {
                    VMRolPrivilegio usuarioRolPriv = new VMRolPrivilegio();
                    usuarioRolPriv.rolId = rolUsuario.id.ToString();
                    usuarioRolPriv.privilegioId = privi.id;
                    listaUsuarioRolPriv.Add(usuarioRolPriv);
                }
            }

            usuario.listaUsuarioRol = Newtonsoft.Json.JsonConvert.SerializeObject(listaUsuarioRolPriv);

            List<VMAplicationRol> listaRolSinPrivilegios = new List<VMAplicationRol>();
            foreach (SISST.ViewModels.Comunes.Roles.VMRol rolApi in listaUsuarioRol)
            {
                VMAplicationRol rolUsuario = new VMAplicationRol();
                rolUsuario.Id = rolApi.id;
                rolUsuario.Name = rolApi.Name;
                rolUsuario.descripcion = rolApi.descripcion;
                
                List<VMPrivilegio> listaPriv = await _privilegiosProxy.GetPrivilegiosByRol(rolApi.id);
                if (listaPriv.Count == 0)
                    listaRolSinPrivilegios.Add(rolUsuario);
            }
            
            foreach( var rolLista in usuario.listaRoles)
            {
                var EsSeleccionable = listaUsuarioRol.Where(x => x.id == rolLista.Id).Count();
                if (EsSeleccionable > 0)
                {
                    rolLista.esSeleccionado = true;
                }
                else
                {
                    rolLista.esSeleccionado = false;
                }
            }
            usuario.lstRolSinPrivilegios = Newtonsoft.Json.JsonConvert.SerializeObject(listaRolSinPrivilegios);
            usuario.accion = "crear";
            return usuario;
        }

        // POST: USuariosController/Edit/5
        [Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(VMUsuario usuarioInfo)
        {
            VMUsuario user = await _usuarioProxy.GetByIdAsync(usuarioInfo.Id);
            var esAdmin = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("EsAdmin", StringComparison.OrdinalIgnoreCase))?.Value;
            if (esAdmin.Equals("1"))
            {
                user.IsAdmin = true;
            }
            else
            {
                user.IsAdmin = false;
            }
            /* Verifica el total de roles */
            string listaRol = HttpContext.Request.Form[key: "listaRol"].ToString();
            if (listaRol.Equals(string.Empty))
            {
                //TempData["tipoMensaje"] = "warning";
                //TempData["mensaje"] = "Seleccionar al menos un rol. ";
                user = await llenarDatosCreate(user);
                user = await llenarDatosEditar(user);
                ModelState.AddModelError("", "Seleccionar al menos un rol.");
                return View(user);
            }
            else
            {


                if (ModelState.IsValid)
                {

                    VMUsuarioUpdate cambios = usuarioInfo.Comparar(user);
                    string resultado = "";
                    if (cambios != null)
                    {
                        string idUsuario = User.FindFirst("IdUsuario").Value;
                        var request = await _usuarioProxy.Edit(usuarioInfo.Id, int.Parse(idUsuario), cambios);
                        resultado = await request.Content.ReadAsStringAsync();
                        if (!request.IsSuccessStatusCode)
                        {
                            ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                            TempData["tipoMensaje"] = "warning";
                            TempData["mensaje"] = "Ha ocurrido un error al intentar actualizar el usuario. " + content.Message;
                            user = await llenarDatosCreate(user);
                            user = await llenarDatosEditar(user);
                            return View(usuarioInfo);
                        }
                    }
                    //Si todo salió bien se deben de actualizar los roles y privilegios del usuario
                    //elimino todos los roles del usuario                
                    List<VMRol> listaUsuarioRol = await _usuarioProxy.GetRolesByUser(user.Id);
                    var UsuarioEsAdministrador = false;
                    if ((listaUsuarioRol.Where(t => t.id == 1).Count()) > 0)
                        UsuarioEsAdministrador = true;

                if (listaUsuarioRol.Count > 0)
                {
                    VMAddRemovePrivilegios removeRoles = new VMAddRemovePrivilegios();
                    removeRoles.ids = listaUsuarioRol.Select(x=>x.id).ToList();
                    var request2 = await _usuarioProxy.RemoveRoles(user.Id, removeRoles);
                    if (!request2.IsSuccessStatusCode)
                    {
                        resultado = await request2.Content.ReadAsStringAsync();
                        ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                        TempData["tipoMensaje"] = "warning";
                        TempData["mensaje"] = "Ha ocurrido un error al intentar eliminar los roles al usuario. " + content.Message;
                        user = await llenarDatosCreate(user);
                        user = await llenarDatosEditar(user);
                        return View(user);
                    }
                }
                //se agregan los roles 
                listaRol = HttpContext.Request.Form[key: "listaRol"].ToString();
                if (UsuarioEsAdministrador)
                {
                    if (listaRol.Equals(""))
                        listaRol = "1";
                    else
                        listaRol = "1," + listaRol;
                }
                    if (!listaRol.Equals(string.Empty))
                    {
                        VMAddRemovePrivilegios addRoles = new VMAddRemovePrivilegios();
                        addRoles.ids = listaRol.Split(',').Select(int.Parse).Distinct().ToList();
                        var request3 = await _usuarioProxy.AddRoles(user.Id, addRoles);
                        if (!request3.IsSuccessStatusCode)
                        {
                            resultado = await request3.Content.ReadAsStringAsync();
                            ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                            TempData["tipoMensaje"] = "warning";
                            TempData["mensaje"] = "Ha ocurrido un error al intentar registrar los roles al usuario. " + content.Message;
                            user = await llenarDatosCreate(user);
                            user = await llenarDatosEditar(user);
                            return View(user);
                        }

                    }
                    // Sólo si es administrador puede actualizar los privilegios
                    if (user.IsAdmin)
                    {
                        //elimino los privilegios del usuario
                        List<VMPrivilegio> listaUsuarioPrivi = await _privilegiosProxy.GetPrivilegiosByUser(user.Id);
                        if (listaUsuarioPrivi.Count > 0)
                        {
                            VMAddRemovePrivilegios removePrivi = new VMAddRemovePrivilegios();
                            removePrivi.ids = listaUsuarioPrivi.Select(x => x.id).ToList();
                            var request4 = await _usuarioProxy.RemovePrivilegios(user.Id, removePrivi);
                            if (!request4.IsSuccessStatusCode)
                            {
                                resultado = await request4.Content.ReadAsStringAsync();
                                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                                TempData["tipoMensaje"] = "warning";
                                TempData["mensaje"] = "Ha ocurrido un error al intentar eliminar los privilegios al usuario. " + content.Message;
                                user = await llenarDatosCreate(user);
                                user = await llenarDatosEditar(user);
                                return View(user);
                            }
                        }
                        //se agregan los provilegios
                        string listaPrivilegios = HttpContext.Request.Form[key: "listaPrivilegios"].ToString();
                        if (!listaPrivilegios.Equals(string.Empty))
                        {
                            VMAddRemovePrivilegios addPrivilegios = new VMAddRemovePrivilegios();
                            addPrivilegios.ids = listaPrivilegios.Split(',').Select(int.Parse).ToList();
                            var request5 = await _usuarioProxy.AddPrivilegios(user.Id, addPrivilegios);
                            if (!request5.IsSuccessStatusCode)
                            {
                                resultado = await request5.Content.ReadAsStringAsync();
                                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                                TempData["tipoMensaje"] = "warning";
                                TempData["mensaje"] = "Ha ocurrido un error al intentar registrar los privilegios al usuario. " + content.Message;
                                await llenarDatosCreate(user);
                                await llenarDatosEditar(user);
                                return View(user);
                            }
                        }
                    }
                    TempData["tipoMensaje"] = "success";
                    TempData["mensaje"] = "El usuario ha sido actualizado exitosamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    user = await llenarDatosCreate(user);
                    user = await llenarDatosEditar(user);
                    ModelState.AddModelError("", "Hay valores incorrectos, revise los campos del formulario.");
                }
            }
            return View(user);
        }

        // POST: USuariosController/Delete/5
        [Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var request = await _usuarioProxy.Delete(id);
            if (request.IsSuccessStatusCode)
            {
                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El usuario ha sido eliminado exitosamente";
            }
            else
            {
                string resultado = await request.Content.ReadAsStringAsync();
                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                TempData["tipoMensaje"] = "failure";
                TempData["mensaje"] = "Ha ocurrido un error al intentar eliminar el usuario. " + content.Message;
            }
            return RedirectToAction("Index");
        }

        // POST: USuariosController/Delete/5
        [Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deactivate(int idActivate)
        {
            string idUsuario = User.FindFirst("IdUsuario").Value;
            var request = await _usuarioProxy.Deactivate(idActivate, int.Parse(idUsuario));
            if (request.IsSuccessStatusCode)
            {
                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El usuario ha sido modificado exitosamente";
            }
            else
            {
                string resultado = await request.Content.ReadAsStringAsync();
                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                TempData["tipoMensaje"] = "failure";
                TempData["mensaje"] = "Ha ocurrido un error al intentar modificar el usuario. " + content.Message;
            }
            return RedirectToAction("Details",new { id= idActivate });
        }
        [Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(int usuarioId)
        {
            VMUsuario user = await _usuarioProxy.GetByIdAsync( usuarioId );
            string idUsuario = User.FindFirst("IdUsuario").Value;
            var request = await _usuarioProxy.ChangePassword(usuarioId, int.Parse(idUsuario), user.RPE);
            if (request.IsSuccessStatusCode)
            {
                TempData["tipoMensaje"] = "success";
                TempData["mensaje"] = "El usuario ha sido modificado exitosamente";
            }
            else
            {
                string resultado = await request.Content.ReadAsStringAsync();
                ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                TempData["tipoMensaje"] = "failure";
                TempData["mensaje"] = "Ha ocurrido un error al intentar modificar el usuario. " + content.Message;
            }

            //Cerrar sesión
            /*
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Relogin
            var usuarioLogin = ObtieneUsuarioLogueado();
            usuarioLogin.AreaActiva = idArea;//AreaAdministrada Seleccionado
            usuarioLogin.rolActivo = rol;//se asigna el rol Activo
            IdentityAccesso autenticado = await _identityProxy.Login(usuarioLogin);
            if (!autenticado.Succeeded)
            {
                TempData["tipoMensaje"] = "error";
                TempData["mensaje"] = "Ha ocurrido un error al cambiar de centro de trabajo activo. ";
                return RedirectToAction("Index", "Home", new { });
            }
            await RealizarLoginAsync(autenticado, usuarioLogin);
            */
            return RedirectToAction("Details", new { id = usuarioId });
        }

        
        
        [Authorize("ADMIN")]
        [HttpGet]
        public async Task<ActionResult> ChangePassword(int? id)
        {
            VMUsuario user = new VMUsuario();
            if (id == null)
            {
                //TempData["tipoMensaje"] = "warning";
                //TempData["mensaje"] = Utils.Comunes.mensajeNulo;
                //return RedirectToAction("Index");
                var idUsuario = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("IdUsuario", StringComparison.OrdinalIgnoreCase))?.Value;
                id = int.Parse(idUsuario);
            }
            if (id != null)
            {
                user = await _usuarioProxy.GetByIdAsync((int)id);
                user = await llenarDatosDetalle(user);
            }
            else
            {
                TempData["tipoMensaje"] = "warning";
                TempData["mensaje"] = Utils.Comunes.mensajeNulo;
                return RedirectToAction("Index");
            }
            VMUsuarioPassword usuario = new VMUsuarioPassword();
            usuario.Id = user.Id;
            usuario.RPE = user.RPE;
            usuario.Nombre = user.Nombre;
            usuario.Apellidos = user.Apellidos;
            return View(usuario);
        }

        [Authorize("ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(VMUsuarioPassword usuarioInfo)
        {
            //bool returnView = false;
            if( String.IsNullOrEmpty( usuarioInfo.Password ))
            {
                TempData["tipoMensaje"] = "error";
                TempData["mensaje"] = "No se ha definido la contraseña";
            }
            else if (String.IsNullOrEmpty(usuarioInfo.PasswordConfirm))
            {
                TempData["tipoMensaje"] = "error";
                TempData["mensaje"] = "No se ha definido la confirmación de la contraseña";
            }
            else if( usuarioInfo.Password.Equals( usuarioInfo.PasswordConfirm ))
            {
                var usuarioId = usuarioInfo.Id;

                string idUsuarioLogueado = User.FindFirst("IdUsuario").Value;
                var request = await _usuarioProxy.ChangePassword(usuarioId, int.Parse(idUsuarioLogueado), usuarioInfo.PasswordConfirm);
                if (request.IsSuccessStatusCode)
                {
                    TempData["tipoMensaje"] = "success";
                    TempData["mensaje"] = "La contraseña del usuario ha sido modificado exitosamente";
                }
                else
                {
                    string resultado = await request.Content.ReadAsStringAsync();
                    ResponseMessage content = JsonConvert.DeserializeObject<ResponseMessage>(resultado);
                    TempData["tipoMensaje"] = "error";
                    TempData["mensaje"] = "Ha ocurrido un error al intentar modificar la contraseña del usuario. " + content.Message;
                }
            }
            else
            {
                TempData["tipoMensaje"] = "error";
                TempData["mensaje"] = "Las contraseñas no son iguales";
            }
            usuarioInfo.PasswordConfirm = "";
            return View(usuarioInfo);
        }
    }
}
