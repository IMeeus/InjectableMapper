namespace Web.Mapping
{
    public interface IMapper<TIn, TOut>
    {
        TOut Map(TIn model);
    }
}