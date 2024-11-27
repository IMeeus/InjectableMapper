# Injectable Mapper


## Controller / How to use

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

## Model & Dto

```cs
public record Model
{
    public string Name { get; set; }
}

public record ModelDto
{
    public string Name { get; set; }
}
```

## Registration

```cs
public static class ServiceCollectionExtensions
{
    public static void Register(this IServiceCollection services)
    {
        // General mapper that is injected in the controller.
        services.AddScoped<IMapper, Mapper>();

        // Concrete mappers that are called by the general mapper.
        services.AddScoped<IMapper<Model, ModelDto>, ModelToDtoMapper>();
    }
}
```

## Concrete Mapper (Model -> ModelDto)

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

## Concrete Mapper Interface

```cs
public interface IMapper<TIn, TOut>
{
    TOut Map(TIn model);
}
```


## General Injectable Mapper

This is a general mapper that delegates its mapping to other mappers in the service collection.
So with this 1 service, you can access all registered mappers, which reduces the amount of services you need to inject.
When a mapper is not found, an `InvalidOperationException` is thrown with a clear message, so that a developer easily know what's wrong.

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
        var mapper = _serviceProvider.GetRequiredService<IMapper<TIn, TOut>>();
        return mapper.Map(model);
    }
}
```