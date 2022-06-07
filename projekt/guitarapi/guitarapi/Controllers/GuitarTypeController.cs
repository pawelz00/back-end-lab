using guitarapi.Dto;
using guitarapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace guitarapi.Controllers
{
    [ApiController]
    public class GuitarTypeController : Controller
    {
        private readonly IGuitarTypeService guitarTypeService;

        public GuitarTypeController(IGuitarTypeService guitarTypeService)
        {
            this.guitarTypeService = guitarTypeService;
        }

        [HttpGet]
        [Route("api/guitars/types")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GuitarTypeDto>))]
        public IActionResult GetGuitarTypes()
        {
            var types = guitarTypeService.GetGuitarTypes();
            var typesDto = new List<GuitarTypeDto>();

            foreach (var item in types)
            {
                typesDto.Add(new GuitarTypeDto(item));
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(typesDto);
        }
    }
}
