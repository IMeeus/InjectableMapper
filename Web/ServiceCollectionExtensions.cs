using Web.Mapping;
using Web.Models;

namespace Web
{
    public static class ServiceCollectionExtensions
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IMapperV1, MapperV1>();
            services.AddScoped<IMapperV2, MapperV2>();
            services.AddScoped<IMapper<ModelV1, ModelV1Dto>, ModelV1ToDtoMapper>();
            services.AddScoped<IMapper<ModelV2, ModelV2Dto>, ModelV2ToDtoMapper>();
        }
    }
}