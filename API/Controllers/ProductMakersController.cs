using API.DTOs.ProductMakerDTOs;
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
    public class ProductMakersController : ControllerBase
    {
        private readonly IProductMakerRepository _productMakerRepository;
        private readonly IUploadImageService _uploadImageService;
        private readonly IDeleteImageService _deleteImageService;

        public ProductMakersController(IProductMakerRepository productMakerRepository, IUploadImageService uploadImageService, IDeleteImageService deleteImageService)
        {
            _productMakerRepository = productMakerRepository;
            _uploadImageService = uploadImageService;
            _deleteImageService = deleteImageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductMakerSimpleResponse>>> GetAll()
        {
            var productMakers = await _productMakerRepository.GetAllAsync();

            return Ok(productMakers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMakerSimpleResponse>> GetById(int id)
        {
            var productMaker = await _productMakerRepository.GetByIdAsync(id);

            if (productMaker == null)
            {
                return NotFound();
            }

            var productMakerResponse = new ProductMakerSimpleResponse
            {
                Id = productMaker.Id,
                Name = productMaker.Name,
                LogoUrl = productMaker.LogoUrl
            };

            return Ok(productMakerResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ProductMakerSimpleResponse>> Add([FromForm] AddProductMakerSimpleRequest request)
        {
            if (await _productMakerRepository.NameExistsAsync(request.Name))
            {
                return BadRequest(new { message = "Product Maker name already exists" });
            }

            var logoUrl = await _uploadImageService.UploadImage(request.Logo) ?? throw new Exception("Failed to upload image");
            var productMaker = new ProductMaker
            {
                Name = request.Name,
                LogoUrl = logoUrl
            };

            try
            {
                var addedProductMaker = await _productMakerRepository.AddAsync(productMaker);

                return Ok(addedProductMaker);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                if (logoUrl != null) await _deleteImageService.DeleteImage(logoUrl);

                return BadRequest(new { message = "Product Maker name already exists" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductMakerSimpleResponse>> Update(int id, [FromForm] UpdateProductMakerSimpleRequest request)
        {
            if (!string.IsNullOrEmpty(request.Name) && await _productMakerRepository.NameExistsAsync(request.Name))
            {
                return BadRequest(new { message = "Product Maker name already exists" });
            }

            var productMaker = await _productMakerRepository.GetByIdAsync(id);
            if (productMaker == null) return NotFound();


            var oldLogoUrl = productMaker.LogoUrl;
            string? logoUrl = null;
            if (request.Logo != null)
            {
                logoUrl = await _uploadImageService.UploadImage(request.Logo) ?? throw new Exception("Failed to upload image");
            }


            productMaker.Name = request.Name ?? productMaker.Name;
            productMaker.LogoUrl = logoUrl ?? productMaker.LogoUrl;

            try
            {
                await _productMakerRepository.SaveChangesAsync();

                if (logoUrl != null)
                {
                    await _deleteImageService.DeleteImage(oldLogoUrl);
                }

                return Ok(new ProductMakerSimpleResponse
                {
                    Id = productMaker.Id,
                    Name = productMaker.Name,
                    LogoUrl = productMaker.LogoUrl
                });
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                if (logoUrl != null) await _deleteImageService.DeleteImage(logoUrl);

                return BadRequest(new { message = "Product Maker name already exists" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productMaker = await _productMakerRepository.GetByIdAsync(id);

            if (productMaker == null)
            {
                return NotFound();
            }

            try
            {
                await _productMakerRepository.DeleteAsync(productMaker);
                await _deleteImageService.DeleteImage(productMaker.LogoUrl);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
            {
                return BadRequest(new { message = "Product Maker does already have Products" });
            }

            return NoContent();
        }

    }
}
