using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBuildingConfigurationService
    {
        Task<IEnumerable<BuildingConfigurationDto>> GetAllConfigurationsAsync();
        Task<bool> AddConfigurationAsync(BuildingConfigurationDto configurationDto);
        Task<IEnumerable<string>> GetAvailableBuildingTypesAsync();

    }
}
