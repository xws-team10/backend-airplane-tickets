namespace FlyMateAPI.Core.Model
{
    public class Basket : Entity
    {
        public string BuyerId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
        public List<Ticket> tickets { get; set; } = null!;
    }
}
