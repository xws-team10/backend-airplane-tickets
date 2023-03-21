using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Repository;

namespace FlyMateAPI.Core.Service
{
    public class FlightsService
    {
        private readonly FlightsRepository _repository;

        public FlightsService(FlightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Flight>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Flight?> GetByIdAsync(string id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateAsync(Flight newFlight) =>
            await _repository.CreateAsync(newFlight);

        public async Task UpdateAsync(string id, Flight updateFlight) =>
            await _repository.UpdateAsync(id, updateFlight);

        public async Task DeleteAsync(string id) =>
            await _repository.DeleteAsync(id);
    }
}