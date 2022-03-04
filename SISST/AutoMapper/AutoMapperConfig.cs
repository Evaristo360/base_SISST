using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => {
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
