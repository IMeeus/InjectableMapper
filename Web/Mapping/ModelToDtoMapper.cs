using Web.Models;

namespace Web.Mapping
{
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
}