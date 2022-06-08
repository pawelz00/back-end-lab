using guitarapi.Dto;
using guitarapi.Models;
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
        [HttpPost]
        [Route("api/producers")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProducer([FromBody] CreateProducerDto producerdto)
        {
            if(producerdto == null)
                return BadRequest(ModelState);

            var producerexists = producerService.GetProducers().Where(p => p.Name.Trim().ToUpper() == producerdto.Name.Trim().ToUpper()).FirstOrDefault();

            if (producerexists != null)
                return StatusCode(422, "Failed, producer already exists in the database!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var producer = producerService.CreateProducer(new Producer {Name = producerdto.Name});

            return Ok("Created!");
        }

        [HttpDelete("api/producers/{id}")]
        public IActionResult DeleteProducer(int id)
        {
            if (!producerService.ProducerExists(id))
                return NotFound();

            var producer = producerService.GetProducer(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!producerService.DeleteProducer(producer))
                return BadRequest("Something went wrong");

            return NoContent();
        }

    }
}
