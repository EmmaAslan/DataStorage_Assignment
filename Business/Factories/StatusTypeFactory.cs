using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusTypeFactory
{
    
    public static StatusTypeModel CreateStatusType(StatusTypeEntity entity)
    {
        if (entity == null)
            return null!;

        return new StatusTypeModel
        {
            Id = entity.Id,
            StatusName = entity.StatusName
        };
    }
    
    public static StatusTypeEntity CreateStatusType(StatusTypeModel model)
    {
        return new StatusTypeEntity
        {
            Id = model.Id,
            StatusName = model.StatusName
        };
    }
}
