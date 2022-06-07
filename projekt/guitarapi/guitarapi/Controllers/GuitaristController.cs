using guitarapi.Dto;
using guitarapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace guitarapi.Controllers
{
    [ApiController]
    public class GuitaristController : Controller
    {
        private readonly IGuitaristService guitaristService;
        public GuitaristController(IGuitaristService guitaristService)
        {
            this.guitaristService = guitaristService;
        }
        [HttpGet]
        [Route("api/guitarists")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GuitaristDto>))]
        public IActionResult GetGuitarists()
        {
            var guitarists = guitaristService.GetGuitarists();
            var guitaristsDto = new List<GuitaristDto>();

            foreach (var item in guitarists)
            {
                guitaristsDto.Add(new GuitaristDto(item));
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guitaristsDto);
        }

        [HttpGet]
        [Route("api/guitarists/{id}")]
        [ProducesResponseType(200, Type = typeof(GuitaristDto))]
        [ProducesResponseType(400)]
        public IActionResult GetGuitarist(int id)
        {
            if (!guitaristService.GuitaristExists(id))
                return NotFound();

            var guitarist = new GuitaristDto(guitaristService.GetGuitarist(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guitarist);
        }
    }
}
