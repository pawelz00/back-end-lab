using guitarapi.Dto;
using guitarapi.Models;
using guitarapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace guitarapi.Controllers
{
    [ApiController]
    public class GuitaristController : Controller
    {
        private readonly IGuitaristService guitaristService;
        private readonly IGuitarService guitarService;

        public GuitaristController(IGuitaristService guitaristService, IGuitarService guitarService)
        {
            this.guitaristService = guitaristService;
            this.guitarService = guitarService;
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

        [HttpPost]
        [Route("api/guitarists/create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGuitarist([FromQuery] int guitarId, [FromBody] CreateGuitaristDto createGuitaristDto)
        {
            if (createGuitaristDto == null)
                return BadRequest(ModelState);

            var guitarist = guitaristService.GetGuitarists().Where(g => g.FullName.Trim().ToUpper() == createGuitaristDto.FullName.Trim().ToUpper()).FirstOrDefault();
            var guitar = guitarService.GetGuitar(guitarId);

            if (guitar == null)
                return NotFound("Guitar of that id not found in the database!");

            if (guitarist != null)
                return StatusCode(422, "Failed, guitarist already exists in the database!");

            var newGuitarist = new Guitarist(){ FullName = createGuitaristDto.FullName, DateOfBirth = createGuitaristDto.DateOfBirth};

            if (!guitaristService.CreateGuitarist(guitarId, newGuitarist))
                return StatusCode(500, "Something went wrong while saving the entity!");

            return Ok("Succesfully created the guitarist.");
        }

        [HttpDelete("api/guitarists/{id}")]
        public IActionResult DeleteGuitarist(int id)
        {
            if (!guitaristService.GuitaristExists(id))
                return NotFound();

            var guitarist = guitaristService.GetGuitarist(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!guitaristService.DeleteGuitarist(guitarist))
                return BadRequest("Something went wrong");

            return NoContent();
        }

        [HttpPut("api/guitarists/addguitar")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult AddGuitarToGuitarist([FromBody]AddGuitarToGuitaristDto updatedGuitarist)
        {
            if (updatedGuitarist == null)
                return BadRequest(ModelState);

            if (!guitaristService.GuitaristExists(updatedGuitarist.Id))
                return NotFound("Guitarist of that ID not found.");

            if (!guitarService.GuitarExists(updatedGuitarist.guitarId))
                return NotFound("Guitar of that ID not found.");

            if (!ModelState.IsValid)
                return BadRequest();

            if (!guitaristService.AddGuitarToGuitarist(updatedGuitarist))
                return StatusCode(500, ModelState);

            return NoContent();
        }
    }
}
