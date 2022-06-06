using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todo_api.Dto;
using todo_api.Services;

namespace todo_api.Controllers
{
    public class PriorityController : Controller
    {
        private readonly IPriorityService priorityservice;
        public PriorityController(IPriorityService priorityservice)
        {
            this.priorityservice = priorityservice;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PriorityDto))]
        [ProducesResponseType(400)]
        public IActionResult GetPriority(int id)
        {
            if (!priorityservice.PriorityExists(id))
                return NotFound();

            var pr = new PriorityDto(priorityservice.GetPriority(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pr);

        }
    }
}
