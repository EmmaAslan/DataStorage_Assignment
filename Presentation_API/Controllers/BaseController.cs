using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IProjectService _projectService;
        private readonly IProjectManagerService _projectManagerService;
        private readonly IServiceService _serviceService;
        private readonly IStatusTypeService _statusTypeService;

        public BaseController(ICustomerService customerService, IProjectService projectService, IProjectManagerService projectManagerService, IServiceService serviceService, IStatusTypeService statusTypeService)
        {
            _customerService = customerService;
            _projectService = projectService;
            _projectManagerService = projectManagerService;
            _serviceService = serviceService;
            _statusTypeService = statusTypeService;

        }

        #region Customer
        [HttpGet("customer")]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            if (customers is null)
                return BadRequest("No customers was found");

            return Ok(customers);
        }

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomer(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null)
                return BadRequest("No customer was found with this Id.");
            
            return Ok(customer);
        }

        //Använde ChatGPT 4o för att få hjälp på ett ungefär hur man skapar en Post.
        [HttpPost("customer")]
        public async Task<ActionResult<CustomerModel>> CreateCustomer([FromBody] CustomerRegistrationForm form)
        { 
            if(form is null)
                return BadRequest("Customer model is null");

            var customer = await _customerService.CreateAsync(form);
            
            if (customer is null)
                return BadRequest("Customer was not created");

            return Ok(customer);
        }

        //Använde ChatGPT 4o för att få hjälp hur man strukturerar en Put.
        [HttpPut("customer")]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer([FromBody] CustomerModel customer)
        {
            if(customer == null)
                return BadRequest("Invalid data");

            var updatedCustomer = await _customerService.UpdateAsync(customer);

            if(updatedCustomer is null)
                return BadRequest("Customer was not updated");

            return Ok(updatedCustomer);
        }

        [HttpDelete("customer/{id}")]
        public async Task<ActionResult<CustomerModel>> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteAsync(id);

            if (customer is false)
                return BadRequest("Customer was not deleted.");

            return Ok(customer);
        }

        #endregion

        #region ProjectManager
        [HttpGet("projectmanager")]
        public async Task<ActionResult<IEnumerable<ProjectManagerModel>>> GetProjectManagers()
        {
            var projectManager = await _projectManagerService.GetAllAsync();

            if (projectManager is null)
                return BadRequest("No project managers was found");

            return Ok(projectManager);
        }

        [HttpGet("projectmanager/{id}")]
        public async Task<ActionResult<ProjectManagerModel>> GetProjectManager(int id)
        {
            var projectManager = await _projectManagerService.GetByIdAsync(id);

            if (projectManager is null)
                return BadRequest("No project manager was found with this Id.");

            return Ok(projectManager);
        }

        [HttpPost("projectmanager")]
        public async Task<ActionResult<ProjectManagerModel>> CreateProjectManager([FromBody] ProjectManagerRegistrationForm form)
        {
            if (form is null)
                return BadRequest("Project Manager model is null");

            var projectManager = await _projectManagerService.CreateAsync(form);

            if (projectManager is null)
                return BadRequest("Project Manager was not created");

            return Ok(projectManager);
        }

        [HttpPut("projectmanager")]
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

        [HttpDelete("projectmanager/{id}")]
        public async Task<ActionResult<ProjectManagerModel>> DeleteProjectManager(int id)
        {
            var projectManager = await _projectManagerService.DeleteAsync(id);

            if (projectManager is false)
                return BadRequest("Project Manager was not deleted.");

            return Ok(projectManager);
        }

        #endregion

        #region Project
        [HttpGet("project")]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProjects()
        {
            var project = await _projectService.GetAllAsync();
            if (project is null)
                return BadRequest("No projects was found");

            return Ok(project);
        }

        [HttpGet("project/{id}")]
        public async Task<ActionResult<ProjectModel>> GetProject(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project is null)
                return BadRequest("No project was found with this Id.");
            return Ok(project);
        }

        [HttpPost("project")]
        public async Task<ActionResult<ProjectModel>> CreateProject([FromBody] ProjectRegistrationForm form)
        {
            if (form is null)
                return BadRequest("Project model is null");

            var project = await _projectService.CreateAsync(form);

            if (project is null)
                return BadRequest("Project was not created");

            return Ok(project);
        }

        [HttpPut("project/{id}")]
        public async Task<ActionResult<ProjectModel>> UpdateProject([FromBody] ProjectModel project)
        {
            if (project == null)
                return BadRequest("Invalid data");

            var updatedProject = await _projectService.UpdateAsync(project);

            if (updatedProject is null)
                return BadRequest("Project was not updated");

            return Ok(updatedProject);
        }

        [HttpDelete("project/{id}")]
        public async Task<ActionResult<ProjectModel>> DeleteProject(int id)
        {
            var project = await _projectService.DeleteAsync(id);

            if (project is false)
                return BadRequest("Project was not deleted.");

            return Ok(project);
        }
        #endregion

        #region Service
        [HttpGet("service")]
        public async Task<ActionResult<IEnumerable<ServiceModel>>> GetServices()
        {
            var service = await _serviceService.GetAllAsync();
            if (service is null)
                return BadRequest("No services was found");

            return Ok(service);
        }

        [HttpGet("service/{id}")]
        public async Task<ActionResult<ServiceModel>> GetService(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service is null)
                return BadRequest("No service was found with this Id.");
            return Ok(service);
        }

        [HttpPost("service")]
        public async Task<ActionResult<ServiceModel>> CreateService([FromBody] ServiceRegistrationForm form)
        {
            if (form is null)
                return BadRequest("Service model is null");

            var service = await _serviceService.CreateAsync(form);

            if (service is null)
                return BadRequest("Service was not created");

            return Ok(service);
        }

        [HttpPut("service")]
        public async Task<ActionResult<ServiceModel>> UpdateService([FromBody] ServiceModel service)
        {
            if (service == null)
                return BadRequest("Invalid data");

            var updatedService = await _serviceService.UpdateAsync(service);

            if (updatedService is null)
                return BadRequest("Service was not updated");

            return Ok(updatedService);
        }

        [HttpDelete("service/{id}")]
        public async Task<ActionResult<ServiceModel>> DeleteService(int id)
        {
            var service = await _serviceService.DeleteAsync(id);

            if (service is false)
                return BadRequest("Service was not deleted.");

            return Ok(service);
        }
        #endregion

        #region StatusType
        [HttpGet("statustype")]
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

