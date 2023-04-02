using FlyMateAPI.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlyMateAPI.Core.Repository.Core
{
    public interface IBasketRepository
    {
        Task<List<Basket>> GetAllAsync();
        Task<Basket?> GetByIdAsync(string id);
        Task CreateAsync(Basket newBasket);
        Task UpdateAsync(string id, Basket updateBasket);
        Task DeleteAsync(string id);
    }
}
