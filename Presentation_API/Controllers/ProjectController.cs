using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;

        #region Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProjects()
        {
            var project = await _projectService.GetAllAsync();
            if (project is null)
                return BadRequest("No projects was found");

            return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProject(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project is null)
                return BadRequest("No project was found with this Id.");
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] ProjectRegistrationForm form)
        {
            if (form is null)
                return BadRequest("Project model is null");

            await _projectService.CreateAsync(form);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectModel>> UpdateProject([FromBody] ProjectModel project)
        {
            if (project == null)
                return BadRequest("Invalid data");

            var updatedProject = await _projectService.UpdateAsync(project);

            if (updatedProject is null)
                return BadRequest("Project was not updated");

            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectModel>> DeleteProject(int id)
        {
            var project = await _projectService.DeleteAsync(id);

            if (project is false)
                return BadRequest("Project was not deleted.");

            return Ok(project);
        }
        #endregion
    }
}
