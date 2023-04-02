using System.ComponentModel;

namespace FlyMateAPI.Core.DTO
{
    public class CreateTicketDTO
    {
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FlightId { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }

    }
}
