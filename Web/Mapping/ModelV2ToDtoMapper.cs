using Web.Models;

namespace Web.Mapping
{
    public class ModelV2ToDtoMapper : IMapper<ModelV2, ModelV2Dto>
    {
        public ModelV2Dto Map(ModelV2 model)
        {
            return new()
            {
                Name = model.Name,
            };
        }
    }
}