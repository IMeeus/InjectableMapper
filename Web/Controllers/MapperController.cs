using Microsoft.AspNetCore.Mvc;
using Web.Mapping;
using Web.Models;

namespace Web.Controllers
{
    [ApiController]
    public class MapperController : ControllerBase
    {
        private readonly IMapperV1 _mapperV1;
        private readonly IMapperV2 _mapperV2;

        public MapperController(IMapperV1 mapper, IMapperV2 mapperV2)
        {
            _mapperV1 = mapper;
            _mapperV2 = mapperV2;
        }

        [HttpGet(nameof(ModelV1))]
        public ModelV1Dto ModelV1()
        {
            return _mapperV1.Map<ModelV1Dto>(new ModelV1()
            {
                Name = nameof(ModelV1)
            });
        }

        [HttpGet(nameof(ModelV2))]
        public ModelV2Dto ModelV2()
        {
            return _mapperV2.Map<ModelV2, ModelV2Dto>(new()
            {
                Name = nameof(ModelV2)
            });
        }
    }
}