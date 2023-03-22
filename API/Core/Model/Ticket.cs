namespace FlyMateAPI.Core.Model
{
    public class Ticket : Entity
    {
        public Passenger Passenger { get; set; } = null!;
        public int Price { get; set; }
        public int BasketId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
