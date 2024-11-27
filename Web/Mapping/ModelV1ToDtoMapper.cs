using Web.Models;

namespace Web.Mapping
{
    public class ModelV1ToDtoMapper : IMapper<ModelV1, ModelV1Dto>
    {
        public ModelV1Dto Map(ModelV1 model)
        {
            return new()
            {
                Name = model.Name,
            };
        }
    }
}