namespace Web.Mapping
{
    public interface IMapper
    {
        TOut Map<TIn, TOut>(TIn model);
    }

    public class Mapper : IMapper
    {
        private readonly IServiceProvider _serviceProvider;

        public Mapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TOut Map<TIn, TOut>(TIn model)
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper<TIn, TOut>>();
            return mapper.Map(model);
        }
    }
}