using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlyMateAPI.Core.Model
{
    public class Ticket : Entity
    {
        public string UserId { get; set; } = null!;
        public string FlightId { get; set; } = null!;
        //public int Price { get; set; }
        //public DateTime PurchaseDate { get; set; }
    }
}
