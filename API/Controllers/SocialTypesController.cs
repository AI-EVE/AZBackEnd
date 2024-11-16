using API.DTOs.SocialTypeDTOs;
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
    public class SocialTypesController : ControllerBase
    {
        private readonly ISocialTypeRepository _socialTypeRepository;
        private readonly IUploadImageService _uploadImageService;
        private readonly IDeleteImageService _deleteImageService;

        public SocialTypesController(ISocialTypeRepository socialTypeRepository, IUploadImageService uploadImageService, IDeleteImageService deleteImageService)
        {
            _socialTypeRepository = socialTypeRepository;
            _uploadImageService = uploadImageService;
            _deleteImageService = deleteImageService;
        }


        [HttpGet]
        public async Task<ActionResult<List<SocialTypeSimpleResponse>>> GetAll()
        {
            var socialTypes = await _socialTypeRepository.GetAllAsync();

            return Ok(socialTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialTypeSimpleResponse>> GetById(int id)
        {
            var socialType = await _socialTypeRepository.GetByIdAsync(id);
            if (socialType == null)
            {
                return NotFound();
            }
            var socialTypeSimpleResponse = new SocialTypeSimpleResponse
            {
                Id = socialType.Id,
                Type = socialType.Type,
                LogoUrl = socialType.LogoUrl
            };

            return Ok(socialTypeSimpleResponse);
        }

        [HttpPost]
        public async Task<ActionResult<SocialTypeSimpleResponse>> Add([FromForm] AddSocialTypeSimpleRequest socialType)
        {
            if (await _socialTypeRepository.NameExistsAsync(socialType.Type))
            {
                return BadRequest(new { message = "Social type already exists" });
            }

            var logoUrl = await _uploadImageService.UploadImage(socialType.Logo) ?? throw new Exception("Image upload failed");
            var newSocialType = new SocialType
            {
                Type = socialType.Type,
                LogoUrl = logoUrl
            };

            try
            {
                var newSocialTypeResponse = await _socialTypeRepository.AddAsync(newSocialType);

                return CreatedAtAction(nameof(GetById), new { id = newSocialTypeResponse.Id }, newSocialTypeResponse);
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23505"))
            {
                await _deleteImageService.DeleteImage(logoUrl);
                return BadRequest(new { message = "Social type already exists" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SocialTypeSimpleResponse>> Update(int id, [FromForm] UpdateSocialTypeSimpleRequest socialType)
        {
            if (socialType.Type != null && await _socialTypeRepository.NameExistsAsync(socialType.Type))
            {
                return BadRequest(new { message = "Name already exists" });
            }

            var existingSocialType = await _socialTypeRepository.GetByIdAsync(id);
            if (existingSocialType == null)
            {
                return NotFound();
            }

            string oldLogoUrl = existingSocialType.LogoUrl;
            string? logoUrl = null;
            if (socialType.Logo != null)
            {
                logoUrl = await _uploadImageService.UploadImage(socialType.Logo) ?? throw new Exception("Image upload failed");
            }

            existingSocialType.Type = socialType.Type ?? existingSocialType.Type;
            existingSocialType.LogoUrl = logoUrl ?? existingSocialType.LogoUrl;

            try
            {
                await _socialTypeRepository.SaveChangesAsync();
                if (logoUrl != null)
                {
                    await _deleteImageService.DeleteImage(oldLogoUrl);
                }

                return Ok(new SocialTypeSimpleResponse
                {
                    Id = existingSocialType.Id,
                    Type = existingSocialType.Type,
                    LogoUrl = existingSocialType.LogoUrl
                });
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23505"))
            {
                if (logoUrl != null)
                {
                    await _deleteImageService.DeleteImage(logoUrl);
                }
                return BadRequest(new { message = "Social type already exists" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var socialType = await _socialTypeRepository.GetByIdAsync(id);
            if (socialType == null)
            {
                return NotFound();
            }

            try
            {
                await _socialTypeRepository.DeleteAsync(socialType);
                await _deleteImageService.DeleteImage(socialType.LogoUrl);
                return NoContent();
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23503"))
            {
                return BadRequest(new { message = "Social type is in use" });
            }
        }
    }
}
