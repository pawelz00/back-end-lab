using guitarapi.Dto;
using guitarapi.Models;
using guitarapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace guitarapi.Controllers
{
    [Route("api/guitars")]
    [ApiController]
    public class GuitarController : Controller
    {
        private readonly IGuitarService guitarService;

        public GuitarController(IGuitarService guitarService)
        {
            this.guitarService = guitarService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GuitarDto>))]
        public IActionResult GetGuitars()
        {
            var guitars = guitarService.GetGuitars();
            var guitarsDto = new List<GuitarDto>();

            foreach (var item in guitars)
            {
                guitarsDto.Add(new GuitarDto(item));
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guitarsDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(GuitarDto))]
        [ProducesResponseType(400)]
        public IActionResult GetGuitar(int id)
        {
            if (!guitarService.GuitarExists(id))
                return NotFound();

            var guitar = new GuitarDto(guitarService.GetGuitar(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guitar);
        }

        [HttpGet("{producer:alpha}")]
        public IActionResult GetGuitarsByProducer(string producer)
        {

            var guitars = guitarService.GetGuitarsByProducer(producer);
            var guitarsDto = new List<GuitarDto>();

            foreach (var item in guitars)
            {
                guitarsDto.Add(new GuitarDto(item));
            }

            if (guitarsDto.Count == 0)
                return NotFound("There are no guitars that match this producer.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guitarsDto);
        }

        [HttpGet("type/{type}")]
        public IActionResult GetGuitarsByType(string type)
        {

            var guitars = guitarService.GetGuitarsByType(type);
            var guitarsDto = new List<GuitarDto>();

            foreach (var item in guitars)
            {
                guitarsDto.Add(new GuitarDto(item));
            }

            if (guitarsDto.Count == 0)
                return NotFound("There are no guitars that match this type.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guitarsDto);
        }

        [HttpPost]
        public IActionResult CreateGuitar([FromBody]CreateGuitarDto guitar)
        {
            if (guitar == null)
                return BadRequest(ModelState);

            guitarService.CreateGuitar(new Guitar
            {
                Name = guitar.Name,
                ReleaseDate = guitar.ReleaseDate,
                ProducerId = guitar.ProducerId,
                TypeId = guitar.TypeId,
                StringsId = guitar.StringsId
            });

            return Ok("Guitar Created!");
        }
    }
}
