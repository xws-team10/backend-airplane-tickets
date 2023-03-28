using FlyMateAPI.Core.Model;

namespace FlyMateAPI.Core.Service.Core
{
    public interface IFlightsService
    {
        Task<List<Flight>> GetAllAsync();
        Task<Flight> GetByIdAsync(string id);
        Task CreateAsync(Flight newFlight);
        Task UpdateAsync(string id, Flight updateFlight);
        Task DeleteAsync(string id);
        Task<List<Flight>> GetBySearch(int capacity, DateTime date, string from, string to);

    }
}
