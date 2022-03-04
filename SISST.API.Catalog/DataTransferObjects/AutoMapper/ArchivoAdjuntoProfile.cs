using AutoMapper;
using Comunes.DTOs.ArchivoAdjunto;

namespace SISST.Catalog.DataTransferObjects.AutoMapper
{
    public class ArchivoAdjuntoProfile : Profile
    {
        public ArchivoAdjuntoProfile()
        {

            CreateMap<RequestCreateArchivoAdjunto, SISST.Catalog.Models.ArchivoAdjunto>()
                .ReverseMap()
                ;

            CreateMap<SISST.Catalog.Models.ArchivoAdjunto, ResponseQueryArchivoAdjunto>()
                .ReverseMap()
                ;

        }
    }
}
