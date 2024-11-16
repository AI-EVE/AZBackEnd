using API.DTOs.CarMakerDTOs;
using API.IRepositories;
using API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarMakersController : ControllerBase
    {
        private readonly ICarMakerRepository _carMakerRepository;

        public CarMakersController(ICarMakerRepository carMakerRepository)
        {
            _carMakerRepository = carMakerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSimpleCarMakersAsync()
        {
            var carMakers = await _carMakerRepository.GetSimpleCarMakersAsync();
            return Ok(carMakers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFullCarMakerAsync(int id)
        {
            var carMaker = await _carMakerRepository.GetFullCarMakerAsync(id);

            if (carMaker == null)
            {
                return NotFound();
            }

            return Ok(carMaker);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarMakerAsync([FromForm] AddCarMakerSimpleRequest addCarMakerSimpleRequest, IUploadImageService uploadImageService, IDeleteImageService deleteImageService)
        {
            if (await _carMakerRepository.NameExistsAsync(addCarMakerSimpleRequest.Name))
            {
                return BadRequest(new { message = "Car maker could not be added because it name is already being used." });
            }

            var logoUrl = await uploadImageService.UploadImage(addCarMakerSimpleRequest.Logo);
            if (logoUrl == null)
            {
                return BadRequest(new { message = "Logo could not be uploaded." });
            }

            var carMakerSimpleResponse = await _carMakerRepository.AddCarMakerAsync(addCarMakerSimpleRequest.Name, logoUrl);

            if (carMakerSimpleResponse == null)
            {
                await deleteImageService.DeleteImage(logoUrl);
                return Conflict();
            }

            return Ok(carMakerSimpleResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarMakerAsync(int id, IDeleteImageService deleteImageService)
        {
            var carMaker = await _carMakerRepository.GetCarMakerAsync(id);

            if (carMaker == null)
            {
                return NotFound();
            }

            var isDeleted = await _carMakerRepository.DeleteCarMakerAsync(carMaker);

            if (isDeleted)
            {
                await deleteImageService.DeleteImage(carMaker.LogoUrl);

                return Ok();
            }

            return BadRequest(new { message = "Car maker could not be deleted because it is being used by a car generation that is related to a car or a product." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarMakerAsync(int id, [FromForm] UpdateCarMakerSimpleRequest updateCarMakerSimpleRequest, IUploadImageService uploadImageService, IDeleteImageService deleteImageService)
        {
            if (!string.IsNullOrEmpty(updateCarMakerSimpleRequest.Name) && await _carMakerRepository.NameExistsAsync(updateCarMakerSimpleRequest.Name))
            {
                return BadRequest(new { message = "Car maker could not be updated because it name is already being used." });
            }

            var carMaker = await _carMakerRepository.GetCarMakerAsync(id);
            if (carMaker == null) return NotFound();


            string? logoUrl = null;

            if (updateCarMakerSimpleRequest.Logo != null)
            {
                logoUrl = await uploadImageService.UploadImage(updateCarMakerSimpleRequest.Logo);

            }

            carMaker.Name = string.IsNullOrEmpty(updateCarMakerSimpleRequest.Name) ? carMaker.Name : updateCarMakerSimpleRequest.Name;
            carMaker.LogoUrl = logoUrl ?? carMaker.LogoUrl;

            var result = await _carMakerRepository.SaveChangesAsync();

            if (result) return Ok(new CarMakerSimpleResponse { Id = carMaker.Id, Name = carMaker.Name, LogoUrl = carMaker.LogoUrl });

            if (logoUrl != null) await deleteImageService.DeleteImage(logoUrl);

            return BadRequest(new { message = "Car maker could not be updated." });
        }
    }
}
