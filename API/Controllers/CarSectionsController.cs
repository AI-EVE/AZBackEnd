using API.DTOs.CarSectionDTOs;
using API.Filters;
using API.IRepositories;
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
        public async Task<ActionResult<List<CarSectionSimpleResponse>>> GetCarSections([FromQuery] CarSectionFilters filters)
        {
            var carSections = await _repository.GetCarSectionsAsync(filters);

            return Ok(carSections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarSectionSimpleResponse>> GetCarSection(int id)
        {
            var carSection = await _repository.GetCarSectionByIdAsync(id);
            if (carSection == null)
            {
                return NotFound();
            }

            var carSectionResponse = new CarSectionSimpleResponse
            {
                Id = carSection.Id,
                Name = carSection.Name
            };

            return Ok(carSectionResponse);
        }

        [HttpPost]
        public async Task<ActionResult<CarSectionSimpleResponse>> PostCarSection(AddCarSectionSimpleRequest carSection)
        {

            try
            {
                var newCarSectionResponse = await _repository.AddCarSectionAsync(carSection);

                return CreatedAtAction(nameof(GetCarSection), new { id = newCarSectionResponse.Id }, newCarSectionResponse);
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23505")
            {
                return BadRequest(new { message = "Car Section name already exists" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarSection(int id, UpdateCarSectionSimpleRequest carSectionUpdateDto)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarSection(int id)
        {
            var carSection = await _repository.GetCarSectionByIdAsync(id);
            if (carSection == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.DeleteCarSectionAsync(carSection);
                return NoContent();
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23503")
            {
                return BadRequest(new { message = "Car Section is in use" });
            }
        }




    }
}
