using Core.Enums;
using System.Text.Json.Serialization;

namespace Core.DTOs
{
    public class BuildingConfigurationDto
    {
        public string BuildingType { get; set; }
        public decimal BuildingCost { get; set; }
        public int ConstructionTime { get; set; }
    }

}
