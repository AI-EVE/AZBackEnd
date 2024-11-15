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
    public class ProductMakerController : ControllerBase
    {
        private readonly IProductMakerRepository _productMakerRepository;
        private readonly IUploadImageService _uploadImageService;
        private readonly IDeleteImageService _deleteImageService;

        public ProductMakerController(IProductMakerRepository productMakerRepository, IUploadImageService uploadImageService, IDeleteImageService deleteImageService)
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

            return Ok(productMaker);
        }

        [HttpPost]
        public async Task<ActionResult<ProductMakerSimpleResponse>> Add([FromForm] AddProductMakerSimpleRequest request)
        {
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
                return BadRequest(new { message = "Product Maker name already exists" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateProductMakerSimpleRequest request)
        {
            var productMaker = await _productMakerRepository.GetByIdAsync(id);

            if (productMaker == null)
            {
                return NotFound();
            }
            var oldLogoUrl = productMaker.LogoUrl;
            var logoUrl = await _uploadImageService.UploadImage(request.Logo);

            productMaker.Name = request.Name ?? productMaker.Name;
            productMaker.LogoUrl = logoUrl ?? productMaker.LogoUrl;

            try
            {
                await _productMakerRepository.SaveChangesAsync();
                await _deleteImageService.DeleteImage(oldLogoUrl);
                return NoContent();
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
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
