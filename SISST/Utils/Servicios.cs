using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SISST.ViewModels.Comunes.Usuarios;
using SISST.ViewModels.Privilegios;


namespace SISST.Utils
{
    public interface IServicios
    {
        List<VMPrivilegio> getPrivilegiosUsuario(out List<VMAplicationRol> roles);
        List<VMPrivilegio> getListaPrivilegiosUsuario();
    }
    public class Servicios : IServicios
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public Servicios(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<VMPrivilegio> getPrivilegiosUsuario(out List<VMAplicationRol> roles)
        {
            var lista = new List<VMPrivilegio>();
            roles = new List<VMAplicationRol>();
            var key = "_privilegios";
            var json = _session.GetString(key);
            Dictionary<string, object> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
            var listaPrivilegios = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMPrivilegio>> (parametros.First(x => x.Key == "model").Value.ToString());

            if(listaPrivilegios.Count()>0)
                lista.AddRange(listaPrivilegios);

            key = "_roles";
            json = _session.GetString(key);           
            Dictionary<string, object> parametros2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
            var listaRoles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMAplicationRol>>(parametros2.First(x => x.Key == "model").Value.ToString());

            if (listaRoles.Count() > 0)
            {
                foreach (var lr in listaRoles)
                {
                    var newRol = new VMAplicationRol();
                    newRol.Id = lr.Id;
                    newRol.Name = lr.Name;
                    newRol.descripcion = lr.descripcion;
                    newRol.esAdmin = lr.esAdmin;
                    roles.Add(newRol);
                    lista.AddRange(lr.rolPrivilegio);
                }
            }
            //key = "_id";
            //var userID = _session.GetString(key);            
            //key = "_email";
            //var userEmail = _session.GetString(key);

            return lista.Distinct().ToList();
        }

        public List<VMPrivilegio> getListaPrivilegiosUsuario()
        {
            var lista = new List<VMPrivilegio>();
            var key = "_rolActivo";
            string rolActivo = _session.GetString(key);   

            key = "_privilegios";
            var json = _session.GetString(key);
            Dictionary<string, object> parametros = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
            var listaPrivilegios = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMPrivilegio>>(parametros.First(x => x.Key == "model").Value.ToString());

            if (listaPrivilegios.Count() > 0)
                lista.AddRange(listaPrivilegios);

            key = "_roles";
            json = _session.GetString(key);
            Dictionary<string, object> parametros2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
            var listaRoles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMAplicationRol>>(parametros2.First(x => x.Key == "model").Value.ToString());

            if (listaRoles.Count() > 0)
            {
                var busca = listaRoles.Where(x => x.Name == rolActivo).FirstOrDefault();
                if(busca!=null)
                {                    
                    lista.AddRange(busca.rolPrivilegio);
                }
            }
           

            return lista.Distinct().ToList();
        }


    }

}
