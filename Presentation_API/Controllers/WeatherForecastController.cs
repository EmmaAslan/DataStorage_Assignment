using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController(IStatusTypeService statusType) : ControllerBase
    {
        private readonly IStatusTypeService _statusType = statusType;
        [HttpGet("statustype")]
        public async Task<ActionResult<IEnumerable<StatusTypeModel>>> Get()
        {
            var statusTypes = await _statusType.GetAllAsync();
            if (statusTypes is null)
                return BadRequest("No status types found");

            return Ok(statusTypes);
        }
    }
}
