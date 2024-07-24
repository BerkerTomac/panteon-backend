using Application.Interfaces;
using Core.DTOs;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BuildingConfigurationService : IBuildingConfigurationService
    {
        private readonly IBuildingConfigurationRepository _repository;

        public BuildingConfigurationService(IBuildingConfigurationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BuildingConfigurationDto>> GetAllConfigurationsAsync()
        {
            var configurations = await _repository.GetAllAsync();
            return configurations.Select(c => new BuildingConfigurationDto
            {
                BuildingType = c.BuildingType.ToString(),
                BuildingCost = c.BuildingCost,
                ConstructionTime = c.ConstructionTime
            });
        }

        public async Task<bool> AddConfigurationAsync(BuildingConfigurationDto configurationDto)
        {
            if (configurationDto.BuildingCost <= 0)
            {
                throw new ArgumentException("Building cost must be greater than zero.");
            }

            if (configurationDto.ConstructionTime < 30 || configurationDto.ConstructionTime > 1800)
            {
                throw new ArgumentException("Construction time must be between 30 and 1800 seconds.");
            }

            if (!Enum.TryParse(configurationDto.BuildingType, out BuildingType buildingType))
            {
                throw new ArgumentException("Invalid building type.");
            }

            var existingConfigurations = await _repository.GetAllAsync();
            if (existingConfigurations.Any(c => c.BuildingType == buildingType))
            {
                throw new ArgumentException("Building type already exists.");
            }

            var configuration = new BuildingConfiguration
            {
                BuildingType = buildingType,
                BuildingCost = configurationDto.BuildingCost,
                ConstructionTime = configurationDto.ConstructionTime
            };

            await _repository.AddAsync(configuration);
            return true;
        }

        public async Task<IEnumerable<string>> GetAvailableBuildingTypesAsync()
        {
            var existingConfigurations = await _repository.GetAllAsync();
            var existingBuildingTypes = existingConfigurations.Select(c => c.BuildingType).ToList();
            var allBuildingTypes = Enum.GetValues(typeof(BuildingType)).Cast<BuildingType>();

            var availableBuildingTypes = allBuildingTypes
                .Where(bt => !existingBuildingTypes.Contains(bt))
                .Select(bt => bt.ToString());

            return availableBuildingTypes;
        }
    }

}
