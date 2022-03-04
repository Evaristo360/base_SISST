using AutoMapper;
using SISST.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.DataTransferObjects.Catalogo
{
    public class AutoMapping : Profile 
    {
        public AutoMapping()
        {
            CreateMap<Configuracion, ResponseQueryConfiguracion>().ReverseMap();
            CreateMap<Configuracion, RequestCreateConfiguracion>().ReverseMap();
            CreateMap<Configuracion, RequestUpdateConfiguracion>().ReverseMap();

            CreateMap<FechaCorte, ResponseQueryFechaCorte>().ReverseMap();
        }
    }
}
