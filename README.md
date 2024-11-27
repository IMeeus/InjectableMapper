# Injectable Mapper

## Controller

```cs
[ApiController]
public class MapperController : ControllerBase
{
    private readonly IMapper _mapper;

    public MapperController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet(nameof(Model))]
    public ModelDto Model()
    {
        return _mapper.Map<Model, ModelDto>(new()
        {
            Name = nameof(Model)
        });
    }
}
```

## Injectable Mapper

```cs
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
        var mapper = _serviceProvider.GetService<IMapper<TIn, TOut>>();
        return mapper.Map(model);
    }
}
```

## Concrete Mapper Interface

```cs
public interface IMapper<TIn, TOut>
{
    TOut Map(TIn model);
}
```

## Concrete Mapper

```cs
public class ModelToDtoMapper : IMapper<Model, ModelDto>
{
    public ModelDto Map(Model model)
    {
        return new()
        {
            Name = model.Name,
        };
    }
}
```

## Registration

```cs
public static class ServiceCollectionExtensions
{
    public static void Register(this IServiceCollection services)
    {
        services.AddScoped<IMapper, Mapper>();
        services.AddScoped<IMapper<Model, ModelDto>, ModelToDtoMapper>();
    }
}
```