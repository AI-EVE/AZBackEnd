using API.DTOs.CarModelDTOs;
using API.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelsController(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }


        [HttpPost]
        public async Task<ActionResult<CarModelSimpleResponse>> AddAsync(AddCarModelSimpleRequest addCarModelSimpleRequest)
        {
            if (string.IsNullOrWhiteSpace(addCarModelSimpleRequest.Name))
            {
                return BadRequest("Car Model name is required");
            }
            try
            {
                var carModelResponse = await _carModelRepository.AddAsync(addCarModelSimpleRequest);

                return Created("", carModelResponse);
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23505")
            {
                return BadRequest("Car Model name already exists");

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdateCarModelSimpleRequest updateCarModelSimpleRequest)
        {
            if (string.IsNullOrWhiteSpace(updateCarModelSimpleRequest.Name))
            {
                return BadRequest("Car Model name is required");
            }
            var carModelToUpdate = await _carModelRepository.GetByIdAsync(id);
            if (carModelToUpdate == null)
            {
                return NotFound();
            }

            carModelToUpdate.Name = updateCarModelSimpleRequest.Name;

            try
            {
                await _carModelRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException)
            {
                return BadRequest("Car Model name already exists");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var carModel = await _carModelRepository.GetByIdAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            _carModelRepository.Delete(carModel);

            try
            {
                await _carModelRepository.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException)
            {
                return BadRequest("Car Model is in use");
            }

            return NoContent();
        }
    }
}
