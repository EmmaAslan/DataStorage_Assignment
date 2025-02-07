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
        return new ProjectManagerModel
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone
        };
    }
}
