using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlyMateAPI.Core.Model
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool Deleted { get; set; } = false;

        public Entity() { }
        public Entity(string id)
        {
            Id = id;
        }
    }
}
