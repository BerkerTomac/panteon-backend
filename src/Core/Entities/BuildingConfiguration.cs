using Core.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BuildingConfiguration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("BuildingType")]
        [BsonRepresentation(BsonType.String)]
        public BuildingType BuildingType { get; set; }

        [BsonElement("BuildingCost")]
        public decimal BuildingCost { get; set; }

        [BsonElement("ConstructionTime")]
        public int ConstructionTime { get; set; }
    }
}