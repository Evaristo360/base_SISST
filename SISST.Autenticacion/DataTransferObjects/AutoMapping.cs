using AutoMapper;
using SISST.Autenticacion.DataTransferObjects.Area;
using SISST.Autenticacion.DataTransferObjects.AreaAdministrada;
using SISST.Autenticacion.DataTransferObjects.Departamento;
using SISST.Autenticacion.DataTransferObjects.Trabajador;
using SISST.Autenticacion.Models;

namespace SISST.Autenticacion.DataTransferObjects
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SISST.Autenticacion.Models.Area, ResponseQueryAllArea>().ReverseMap();//CreateMap<ResponseQueryAllArea, SISST.Autenticacion.Models.Area> ();
            CreateMap<SISST.Autenticacion.Models.Area, ResponseQueryArea>().ReverseMap();//CreateMap<ResponseQueryArea, SISST.Autenticacion.Models.Area>();
            CreateMap<SISST.Autenticacion.Models.Area, ResponseQuerySearch>().ReverseMap();//
                       
            CreateMap<ResponseQueryAllArea, ResponseQueryArea>().ReverseMap();

            //CreateMap<SISST.Autenticacion.Models.Trabajador, RequestCreateTrabajador>().ReverseMap();// CreateMap<RequestCreateTrabajador, SISST.Autenticacion.Models.Trabajador >();
            //CreateMap<SISST.Autenticacion.Models.Trabajador, ResponseCreateTrabajador>().ReverseMap();//CreateMap<ResponseCreateTrabajador, SISST.Autenticacion.Models.Trabajador>();
            //CreateMap<SISST.Autenticacion.Models.Trabajador, ResponseQueryTrabajador>();//CreateMap<ResponseQueryTrabajador, SISST.Autenticacion.Models.Trabajador>();
            //CreateMap<SISST.Autenticacion.Models.Trabajador, RequestUpdateTrabajador>().ReverseMap();// CreateMap<RequestUpdateTrabajador, SISST.Autenticacion.Models.Trabajador>();
            //CreateMap<SISST.Autenticacion.Models.Trabajador, ResponseSearchTrabajador>().ReverseMap();// CreateMap<ResponseSearchTrabajador, SISST.Autenticacion.Models.Trabajador>();
           
            CreateMap<SISST.Autenticacion.Models.AreaAdministrada, ResponseCreateAreaAdministrada>().ReverseMap(); //CreateMap<ResponseCreateAreaAdministrada, SISST.Autenticacion.Models.AreaAdministrada>();
            CreateMap<SISST.Autenticacion.Models.AreaAdministrada, ResponseAreaAdministrada>().ReverseMap(); //CreateMap<ResponseAreaAdministrada, SISST.Autenticacion.Models.AreaAdministrada>();
            
            CreateMap<ResponseQueryDepartamento, SISST.Autenticacion.Models.Departamento>().ReverseMap();
            CreateMap<ResponseQueryCTIdClaveNombre, SISST.Autenticacion.Models.Area>().ReverseMap();
            CreateMap<ResponseQuerySearchDeptoDet, SISST.Autenticacion.Models.DepartamentoDet>().ReverseMap();
        }
    }
}
