using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypeController(IStatusTypeService statusTypeService) : ControllerBase
    {
        private readonly IStatusTypeService _statusTypeService = statusTypeService;

        #region StatusType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusTypeModel>>> GetStatusTypes()
        {
            var statusTypes = await _statusTypeService.GetAllAsync();
            if (statusTypes is null)
                return BadRequest("No status types found");

            return Ok(statusTypes);
        }

        #endregion 
    }
}
