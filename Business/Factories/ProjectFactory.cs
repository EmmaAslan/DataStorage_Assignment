using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    //Skapa en ny ProjectEntity
    public static ProjectEntity CreateProject(ProjectRegistrationForm dto)
    {
        return new ProjectEntity
        {
            Title = dto.Title,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            TotalPrice = dto.TotalPrice,
            ProjectManagerId = dto.ProjectManagerId,
            CustomerId = dto.CustomerId,
            ServiceId = dto.ServiceId,
            StatusTypeId = dto.StatusTypeId
        };
        
    }

    //Skapa en ny ProjectModel från en ProjectEntity
    public static ProjectModel CreateProject(ProjectEntity entity)
    {
        return new ProjectModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            TotalPrice = entity.TotalPrice,
            ProjectManager = ProjectManagerFactory.CreateProjectManager(entity.ProjectManager),
            Customer = CustomerFactory.CreateCustomer(entity.Customer),
            Service = ServiceFactory.CreateService(entity.Service),
            StatusType = StatusTypeFactory.CreateStatusType(entity.StatusType)
        };
    }

    //Skapa en ny ProjectEntity från en ProjectModel
    public static ProjectEntity CreateProject(ProjectModel model)
    {
        return new ProjectEntity
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            TotalPrice = model.TotalPrice,
            ProjectManager = ProjectManagerFactory.CreateProjectManager(model.ProjectManager),
            Customer = CustomerFactory.CreateCustomer(model.Customer),
            Service = ServiceFactory.CreateService(model.Service),
            StatusType = StatusTypeFactory.CreateStatusType(model.StatusType)
            
        };
    }
}
