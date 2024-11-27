namespace Web.Mapping
{
    public interface IMapperV2
    {
        TOut Map<TIn, TOut>(TIn model);
    }

    public class MapperV2 : IMapperV2
    {
        private readonly IServiceProvider _serviceProvider;

        public MapperV2(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TOut Map<TIn, TOut>(TIn model)
        {
            var mapper = _serviceProvider.GetService<IMapper<TIn, TOut>>();
            return mapper.Map(model);
        }
    }
}