using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectManagerFactory
{
    public static ProjectManagerEntity CreateProjectManager(ProjectManagerRegistrationForm dto)
    {
        return new ProjectManagerEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone
        };
    }


   
    public static ProjectManagerModel CreateProjectManager(ProjectManagerEntity entity)
    {
        // Får null när jag skapar Project
        if (entity == null)
            return null!;

        return new ProjectManagerModel
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone
        };
        
    }

    public static ProjectManagerEntity CreateProjectManager(ProjectManagerModel model)
    {
        return new ProjectManagerEntity
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Phone = model.Phone
        };
    }
}
