using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Repository.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlyMateAPI.Core.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IMongoCollection<Basket> _basketCollection;

        public BasketRepository(IOptions<FlightsStoreDatabaseSettings> flightsStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(flightsStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(flightsStoreDatabaseSettings.Value.DatabaseName);
            _basketCollection = mongoDatabase.GetCollection<Basket>(flightsStoreDatabaseSettings.Value.BasketCollectionName);
        }

        public async Task CreateAsync(Basket newBasket) =>
            await _basketCollection.InsertOneAsync(newBasket);

        public async Task DeleteAsync(string id) =>
            await _basketCollection.DeleteOneAsync(x => x.Id == id);

        public async Task<List<Basket>> GetAllAsync() =>
            await _basketCollection.Find(_ => true).ToListAsync();

        public async Task<Basket?> GetByIdAsync(string id) =>
            await _basketCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Basket updateBasket) =>
            await _basketCollection.ReplaceOneAsync(x => x.Id == id, updateBasket);

        public async Task<Basket?> GetBasketByUser(string buyerId)
        {
            return await _basketCollection.Find(x => x.BuyerId == buyerId).FirstOrDefaultAsync();
        }
    }
}
