using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Repository;
using FlyMateAPI.Core.Service.Core;

namespace FlyMateAPI.Core.Service
{
    public class BasketService : IBasketService
    {

        private readonly BasketRepository _repository;

        public BasketService(BasketRepository repository) =>
            _repository = repository;

        public async Task CreateAsync(Basket newBasket) => 
            await _repository.CreateAsync(newBasket);

        public async Task DeleteAsync(string id) =>
            await _repository.DeleteAsync(id);

        public async Task<List<Basket>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Basket?> GetByIdAsync(string id) =>
            await _repository.GetByIdAsync(id); 

        public async Task UpdateAsync(string id, Basket updateBasket) =>
            await _repository.UpdateAsync(id, updateBasket);

        public async Task<Basket?> GetBasket(string buyerId) =>
            await _repository.GetBasketByUser(buyerId);

        public async Task<Basket> CreateBasket() 
        {
            var buyerId = "aa"; //CurrentUser.Id

            var basket = new Basket { BuyerId = buyerId };

            await _repository.CreateAsync(basket);

            return basket;
        }

        public void AddTicket(Flight flight)
        {
            var basket = new Basket();

            if (basket.Tickets.All(ticket => ticket.Id != flight.Id))
            {
                basket.Tickets.Add(new Ticket { Flight = flight });
            }

            var existingTicket = basket.Tickets.FirstOrDefault(ticket => ticket.Id == flight.Id);
            
            if (existingTicket != null)
            {
                throw new InvalidOperationException("You have already purchased ticket for this flight");
            }

        }

    }
}
