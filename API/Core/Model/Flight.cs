using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FlyMateAPI.Core.Model
{
    public class Flight : Entity
    {

        [BsonElement("Airline")]
        public string Airline { get; set; } = null!;
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public int SeatsLeft { get; set; }

        public bool Validate()
        {
            return (Capacity > 0 && Price > 0 && SeatsLeft >= 0 && SeatsLeft <= Capacity && DepartureDateTime <= ArrivalDateTime);
        }
    }
}