using API.DTOs.ProductTypeDTOs;
using API.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;
        public ProductTypesController(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductTypeSimpleResponse>>> GetAll()
        {
            return await _productTypeRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeSimpleResponse>> GetById(int id)
        {
            var productType = await _productTypeRepository.GetByIdAsync(id);
            if (productType == null)
            {
                return NotFound();
            }
            var productTypeSimpleResponse = new ProductTypeSimpleResponse
            {
                Id = productType.Id,
                Name = productType.Name
            };

            return productTypeSimpleResponse;
        }

        [HttpPost]
        public async Task<ActionResult<ProductTypeSimpleResponse>> Add(AddProductTypeSimpleRequest productType)
        {
            try
            {
                var newProductTypeResponse = await _productTypeRepository.AddAsync(productType);


                return CreatedAtAction(nameof(GetById), new { id = newProductTypeResponse.Id }, newProductTypeResponse);
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23505"))
            {
                return BadRequest(new { message = "Product type already exists" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddProductTypeSimpleRequest productType)
        {
            var existingProductType = await _productTypeRepository.GetByIdAsync(id);
            if (existingProductType == null)
            {
                return NotFound();
            }

            existingProductType.Name = productType.Name;

            try
            {
                await _productTypeRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23505"))
            {
                return BadRequest(new { message = "Product type already exists" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var productType = await _productTypeRepository.GetByIdAsync(id);
                if (productType == null)
                {
                    return NotFound();
                }
                await _productTypeRepository.DeleteAsync(productType);
                return NoContent();
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23503"))
            {
                return BadRequest(new { message = "Product type is in use" });
            }
        }
    }
}
