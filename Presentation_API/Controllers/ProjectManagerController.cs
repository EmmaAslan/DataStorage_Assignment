using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagerController(IProjectManagerService projectManagerService ) : ControllerBase
    {
        private readonly IProjectManagerService _projectManagerService = projectManagerService;

        #region ProjectManager
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectManagerModel>>> GetProjectManagers()
        {
            var projectManager = await _projectManagerService.GetAllAsync();

            if (projectManager is null)
                return BadRequest("No project managers was found");

            return Ok(projectManager);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectManagerModel>> GetProjectManager(int id)
        {
            var projectManager = await _projectManagerService.GetByIdAsync(id);

            if (projectManager is null)
                return BadRequest("No project manager was found with this Id.");

            return Ok(projectManager);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProjectManager([FromBody] ProjectManagerRegistrationForm form)
        {
            if (form is null)
                return BadRequest("Project Manager model is null");

            await _projectManagerService.CreateAsync(form);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<CustomerModel>> UpdateProjectManager([FromBody] ProjectManagerModel projectManager)
        {
            // Invalid data om projectManager är null
            if (projectManager == null)
                return BadRequest("Invalid data");

            var updatedProjectManager = await _projectManagerService.UpdateAsync(projectManager);

            if (updatedProjectManager is null)
                return BadRequest("Project Manager was not updated");

            return Ok(updatedProjectManager);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectManagerModel>> DeleteProjectManager(int id)
        {
            var projectManager = await _projectManagerService.DeleteAsync(id);

            if (projectManager is false)
                return BadRequest("Project Manager was not deleted.");

            return Ok(projectManager);
        }

        #endregion
    }
}
