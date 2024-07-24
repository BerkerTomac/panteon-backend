using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BuildingConfigurationRepository : IBuildingConfigurationRepository
    {
        private readonly IMongoCollection<BuildingConfiguration> _buildingConfigurations;

        public BuildingConfigurationRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _buildingConfigurations = database.GetCollection<BuildingConfiguration>("BuildingConfigurations");
        }

        public async Task<IEnumerable<BuildingConfiguration>> GetAllAsync()
        {
            return await _buildingConfigurations.Find(_ => true).ToListAsync();
        }

        public async Task<BuildingConfiguration> GetByIdAsync(string id)
        {
            return await _buildingConfigurations.Find(conf => conf.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(BuildingConfiguration configuration)
        {
            await _buildingConfigurations.InsertOneAsync(configuration);
        }

        public async Task<bool> UpdateAsync(BuildingConfiguration configuration)
        {
            var result = await _buildingConfigurations.ReplaceOneAsync(conf => conf.Id == configuration.Id, configuration);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _buildingConfigurations.DeleteOneAsync(conf => conf.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
