using API.DTOs.CarGenerationDTOs;
using API.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarGenerationsController : ControllerBase
    {
        private readonly ICarGenerationRepository _carGenerationRepository;

        public CarGenerationsController(ICarGenerationRepository carGenerationRepository)
        {
            _carGenerationRepository = carGenerationRepository;
        }


        [HttpPost]
        public async Task<ActionResult<carGenerationSimpleResponse>> AddAsync(AddCarGenerationSimpleRequest addCarGenerationSimpleRequest)
        {
            if (string.IsNullOrWhiteSpace(addCarGenerationSimpleRequest.Name))
            {
                return BadRequest("Car Generation name is required");
            }
            try
            {
                var carGenerationResponse = await _carGenerationRepository.AddAsync(addCarGenerationSimpleRequest);

                return Created("", carGenerationResponse);
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23505")
            {
                return BadRequest("Car Generation name already exists");

            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdateCarGenerationSimpleRequest updateCarGenerationSimpleRequest)
        {
            if (string.IsNullOrWhiteSpace(updateCarGenerationSimpleRequest.Name))
            {
                return BadRequest("Car Generation name is required");
            }
            var carGenerationToUpdate = await _carGenerationRepository.GetByIdAsync(id);
            if (carGenerationToUpdate == null)
            {
                return NotFound();
            }

            carGenerationToUpdate.Name = updateCarGenerationSimpleRequest.Name;

            try
            {
                await _carGenerationRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException)
            {
                return BadRequest("Car Generation name already exists");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var carGeneration = await _carGenerationRepository.GetByIdAsync(id);
            if (carGeneration == null)
            {
                return NotFound();
            }

            _carGenerationRepository.Delete(carGeneration);

            try
            {
                await _carGenerationRepository.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException)
            {
                return BadRequest("Car Generation is in use");
            }

            return NoContent();
        }

    }
}
