using Web.Mapping;
using Web.Models;

namespace Web
{
    public static class ServiceCollectionExtensions
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IMapper<Model, ModelDto>, ModelToDtoMapper>();
        }
    }
}