using FlyMateAPI.Core.Model;

namespace FlyMateAPI.Core.Service.Core
{
    public interface IBasketService
    {
        Task<List<Basket>> GetAllAsync();
        Task<Basket?> GetByIdAsync(string id);
        Task CreateAsync(Basket newBasket);
        Task UpdateAsync(string id, Basket updateBasket);
        Task DeleteAsync(string id);
    }
}
