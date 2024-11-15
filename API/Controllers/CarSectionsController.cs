using API.DTOs.CarSectionDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSectionsController : ControllerBase
    {
        private readonly ICarSectionRepository _repository;
        public CarSectionsController(ICarSectionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarSection>>> GetCarSections()
        {
            var carSections = await _repository.GetCarSectionsAsync();
            return Ok(carSections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarSection>> GetCarSection(int id)
        {
            var carSection = await _repository.GetCarSectionByIdAsync(id);
            if (carSection == null)
            {
                return NotFound();
            }
            return Ok(carSection);
        }

        [HttpPost]
        public async Task<ActionResult<CarSection>> PostCarSection(CarSection carSection)
        {
            try
            {
                var newCarSection = await _repository.AddCarSectionAsync(carSection);
                return CreatedAtAction(nameof(GetCarSection), new { id = newCarSection.Id }, newCarSection);
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23505")
            {
                return BadRequest(new { message = "Car Section name already exists" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CarSection>> DeleteCarSection(int id)
        {
            var carSection = await _repository.GetCarSectionByIdAsync(id);
            if (carSection == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.DeleteCarSectionAsync(carSection);
                return Ok(carSection);
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23503")
            {
                return BadRequest(new { message = "Car Section is in use" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarSection(int id, CarSectionUpdateDto carSectionUpdateDto)
        {
            var carSection = await _repository.GetCarSectionByIdAsync(id);
            if (carSection == null)
            {
                return NotFound();
            }

            carSection.Name = carSectionUpdateDto.Name;

            try
            {
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23505")
            {
                return BadRequest(new { message = "Car Section name already exists" });
            }
        }


    }
}
