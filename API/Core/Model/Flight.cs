using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlyMateAPI.Core.Model
{
    public class Flight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Capacity { get; set; } = null!;

        public string Company { get; set; } = null!;
    }
}
