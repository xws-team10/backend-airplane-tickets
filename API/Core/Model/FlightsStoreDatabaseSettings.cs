namespace FlyMateAPI.Core.Model;

public class FlightsStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string FlightsCollectionName { get; set; } = null!;

    public string BasketCollectionName { get; set; } = null!;
    public string TicketCollectionName { get; set; } = null!;
}