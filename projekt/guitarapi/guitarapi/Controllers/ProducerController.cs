using guitarapi.Dto;
using guitarapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace guitarapi.Controllers
{
    [ApiController]
    public class ProducerController : Controller
    {
        private readonly IProducerService producerService;

        public ProducerController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        [HttpGet]
        [Route("api/guitars/producers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProducerDto>))]
        public IActionResult GetProducers()
        {
            var producers = producerService.GetProducers();
            var producersDto = new List<ProducerDto>();

            foreach (var item in producers)
            {
                producersDto.Add(new ProducerDto(item));
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(producersDto);
        }
    }
}
