using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class StatusTypeService(IStatusTypeRepository _repository) : IStatusTypeService
{
    public async Task<IEnumerable<StatusTypeModel>> GetAllAsync()
    {
        var statusEntities = await _repository.GetAllAsync();
        return statusEntities.Select(StatusTypeFactory.CreateStatusType).ToList();
    }
}

