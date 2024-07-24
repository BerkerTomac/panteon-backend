using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Enums
{
    public class BuildingTypeConverter : JsonConverter<BuildingType>
    {
        public override BuildingType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string enumString = reader.GetString();
            return enumString switch
            {
                "Farm" => BuildingType.Farm,
                "Academy" => BuildingType.Academy,
                "Headquarters" => BuildingType.Headquarters,
                "LumberMill" => BuildingType.LumberMill,
                "Barracks" => BuildingType.Barracks,
                _ => throw new JsonException($"Unknown BuildingType: {enumString}")
            };
        }

        public override void Write(Utf8JsonWriter writer, BuildingType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
