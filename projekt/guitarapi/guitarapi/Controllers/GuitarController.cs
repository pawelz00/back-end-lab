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

        [HttpGet("{id}")]
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
    }
}
