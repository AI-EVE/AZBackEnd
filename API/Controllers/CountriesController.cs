using API.DTOs.CountryDTOs;
using API.IRepositories;
using API.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUploadImageService _uploadImageService;
        private readonly IDeleteImageService _deleteImageService;

        public CountriesController(ICountryRepository countryRepository, IUploadImageService uploadImageService, IDeleteImageService deleteImageService)
        {
            _countryRepository = countryRepository;
            _uploadImageService = uploadImageService;
            _deleteImageService = deleteImageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CountrySimpleResponse>>> GetAll()
        {
            var countries = await _countryRepository.GetAllAsync();

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountrySimpleResponse>> GetById(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryResponse = new CountrySimpleResponse
            {
                Id = country.Id,
                Name = country.Name,
                FlagUrl = country.FlagUrl
            };

            return Ok(countryResponse);
        }

        [HttpPost]
        public async Task<ActionResult<CountrySimpleResponse>> Add([FromForm] AddCountrySimpleRequest request)
        {
            if (await _countryRepository.NameExistsAsync(request.Name))
            {
                return BadRequest(new { message = "Country name already exists" });
            }

            var flagUrl = await _uploadImageService.UploadImage(request.Flag) ?? throw new Exception("Failed to upload image");
            var country = new Country
            {
                Name = request.Name,
                FlagUrl = flagUrl
            };

            try
            {
                var addedCountry = await _countryRepository.AddAsync(country);

                return Ok(addedCountry);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                if (flagUrl != null) await _deleteImageService.DeleteImage(flagUrl);

                return BadRequest(new { message = "Country name already exists" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CountrySimpleResponse>> Update(int id, [FromForm] UpdateCountrySimpleRequest request)
        {
            if (!string.IsNullOrEmpty(request.Name) && await _countryRepository.NameExistsAsync(request.Name))
            {
                return BadRequest(new { message = "Country name already exists" });
            }

            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }
            var oldFlagUrl = country.FlagUrl;
            var flagUrl = await _uploadImageService.UploadImage(request.Flag);

            country.Name = request.Name ?? country.Name;
            country.FlagUrl = flagUrl ?? country.FlagUrl;

            try
            {
                await _countryRepository.SaveChangesAsync();
                if (flagUrl != null)
                {
                    await _deleteImageService.DeleteImage(oldFlagUrl);
                }
                return Ok(new CountrySimpleResponse
                {
                    Id = country.Id,
                    Name = country.Name,
                    FlagUrl = country.FlagUrl
                });
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                if (flagUrl != null) await _deleteImageService.DeleteImage(flagUrl);

                return BadRequest(new { message = "Country name already exists" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            try
            {
                await _countryRepository.DeleteAsync(country);
                await _deleteImageService.DeleteImage(country.FlagUrl);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
            {
                return BadRequest(new { message = "Country does already have Products" });
            }

            return NoContent();
        }

    }
}
