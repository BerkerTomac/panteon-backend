using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBuildingConfigurationRepository
    {
        Task<IEnumerable<BuildingConfiguration>> GetAllAsync();
        Task<BuildingConfiguration> GetByIdAsync(string id);
        Task AddAsync(BuildingConfiguration configuration);
        Task<bool> UpdateAsync(BuildingConfiguration configuration);
        Task<bool> DeleteAsync(string id);
    }
}
