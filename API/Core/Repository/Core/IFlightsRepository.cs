using FlyMateAPI.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlyMateAPI.Core.Repository.Core
{
    public interface IFlightsRepository
    {
        Task<List<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(string id);
        Task CreateAsync(Flight newFlight);
        Task UpdateAsync(string id, Flight updateFlight);
        Task DeleteAsync(string id);
    }
}
