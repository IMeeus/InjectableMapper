namespace Web.Mapping
{
    public interface IMapperV1
    {
        TOut Map<TOut>(object model);
    }

    public class MapperV1 : IMapperV1
    {
        private readonly IServiceProvider _serviceProvider;

        public MapperV1(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TOut Map<TOut>(object model)
        {
            var inputType = model.GetType();
            var outputType = typeof(TOut);
            var mapperType = typeof(IMapper<,>).MakeGenericType(inputType, outputType);

            var mapper = _serviceProvider.GetRequiredService(mapperType);
            var method = mapper.GetType().GetMethod(nameof(Map));

            return (TOut)method.Invoke(mapper, new[] { model });
        }
    }
}