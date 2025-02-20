using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(IServiceService serviceService) : ControllerBase
    {
        private readonly IServiceService _serviceService = serviceService;

        #region Service
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceModel>>> GetServices()
        {
            var service = await _serviceService.GetAllAsync();
            if (service is null)
                return BadRequest("No services was found");

            return Ok(service);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceModel>> GetService(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service is null)
                return BadRequest("No service was found with this Id.");
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult> CreateService([FromBody] ServiceRegistrationForm form)
        {
            if (form is null)
                return BadRequest("Service model is null");

            await _serviceService.CreateAsync(form);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<ServiceModel>> UpdateService([FromBody] ServiceModel service)
        {
            if (service == null)
                return BadRequest("Invalid data");

            var updatedService = await _serviceService.UpdateAsync(service);

            if (updatedService is null)
                return BadRequest("Service was not updated");

            return Ok(updatedService);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceModel>> DeleteService(int id)
        {
            var service = await _serviceService.DeleteAsync(id);

            if (service is false)
                return BadRequest("Service was not deleted.");

            return Ok(service);
        }
        #endregion
    }
}
