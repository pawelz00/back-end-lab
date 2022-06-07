using guitarapi.Dto;
using guitarapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace guitarapi.Controllers
{
    [ApiController]
    public class GuitarStringsController : Controller
    {
        private readonly IStringsService stringsService;

        public GuitarStringsController(IStringsService stringsService)
        {
            this.stringsService = stringsService;
        }

        [HttpGet]
        [Route("api/guitars/strings")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StringsDto>))]
        public IActionResult GetProducers()
        {
            var guitarstrings = stringsService.GetGuitarStrings();
            var guitarstringsDto = new List<StringsDto>();

            foreach (var item in guitarstrings)
            {
                guitarstringsDto.Add(new StringsDto(item));
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guitarstringsDto);
        }
    }
}
