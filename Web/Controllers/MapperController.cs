using Microsoft.AspNetCore.Mvc;
using Web.Mapping;
using Web.Models;

namespace Web.Controllers
{
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
}