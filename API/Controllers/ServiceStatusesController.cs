using API.DTOs.ServiceStatusDTOs;
using API.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceStatusesController : ControllerBase
    {
        private readonly IServiceStatusRepository _serviceStatusRepository;

        public ServiceStatusesController(IServiceStatusRepository serviceStatusRepository)
        {
            _serviceStatusRepository = serviceStatusRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceStatusSimpleResponse>>> GetServiceStatusesAsync()
        {
            var serviceStatuses = await _serviceStatusRepository.GetServiceStatusesAsync();
            return Ok(serviceStatuses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceStatusSimpleResponse>> GetServiceStatusAsync(int id)
        {
            var serviceStatus = await _serviceStatusRepository.GetServiceStatusAsync(id);

            if (serviceStatus == null)
            {
                return NotFound();
            }

            return Ok(serviceStatus);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceStatusSimpleResponse>> AddServiceStatusAsync(AddServiceStatusSimpleRequest request)
        {
            try
            {
                var serviceStatusResponse = await _serviceStatusRepository.AddServiceStatusAsync(request);
                return CreatedAtAction(nameof(GetServiceStatusAsync), new { id = serviceStatusResponse.Id }, serviceStatusResponse);
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23505"))
            {
                return Conflict(new { message = "Service status already exists" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceStatusAsync(int id)
        {
            var serviceStatus = await _serviceStatusRepository.GetServiceStatusAsync(id);

            if (serviceStatus == null)
            {
                return NotFound();
            }

            try
            {
                await _serviceStatusRepository.DeleteServiceStatusAsync(serviceStatus);
                return NoContent();
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23503"))
            {
                return BadRequest(new { message = "Service status is in use" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceStatusAsync(int id, AddServiceStatusSimpleRequest request)
        {
            var serviceStatus = await _serviceStatusRepository.GetServiceStatusAsync(id);

            if (serviceStatus == null)
            {
                return NotFound();
            }

            serviceStatus.Status = request.Status ?? serviceStatus.Status;
            serviceStatus.Description = request.Description ?? serviceStatus.Description;

            try
            {
                await _serviceStatusRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex) when ((ex.InnerException is PostgresException pgEx) && (pgEx.SqlState == "23505"))
            {
                return Conflict(new { message = "Service status already exists" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
