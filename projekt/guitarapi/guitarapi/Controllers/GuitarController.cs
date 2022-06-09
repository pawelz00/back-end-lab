﻿using guitarapi.Dto;
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

            var checkCorrectness = guitarService.CheckIfProducerAndTypeAndStringsExists(guitar.ProducerId, guitar.StringsId, guitar.TypeId);

            if (checkCorrectness == false)
                return BadRequest("Bad ProducerId or TypeId or StringsId.");

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

        [HttpDelete("{id}")]
        public IActionResult DeleteGuitar(int id)
        {
            if (!guitarService.GuitarExists(id))
                return NotFound();

            var guitar = guitarService.GetGuitar(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!guitarService.DeleteGuitar(guitar))
                return BadRequest("Something went wrong");

            return NoContent();
        }
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGuitar([FromBody]UpdateGuitarDto updatedGuitar)
        {
            if (updatedGuitar == null)
                return BadRequest(ModelState);

            var nameExists = guitarService.GetGuitars().Where(p => p.Name.Trim().ToUpper() == updatedGuitar.Name.Trim().ToUpper()).FirstOrDefault();

            if (nameExists != null)
                return StatusCode(422, "Failed, producer already exists in the database!");

            if (!guitarService.GuitarExists(updatedGuitar.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var checkCorrectness = guitarService.CheckIfProducerAndTypeAndStringsExists(updatedGuitar.ProducerId, updatedGuitar.StringsId, updatedGuitar.TypeId);

            if (checkCorrectness == false)
                return BadRequest("Bad ProducerId or TypeId or StringsId.");

            var guitar = new Guitar() { Id = updatedGuitar.Id, Name = updatedGuitar.Name, TypeId = updatedGuitar.TypeId, ProducerId = updatedGuitar.ProducerId, StringsId = updatedGuitar.StringsId, ReleaseDate = updatedGuitar.ReleaseDate };

            if (!guitarService.UpdateGuitar(guitar))
                return StatusCode(500, ModelState);

            return NoContent();
        }
    }
}
