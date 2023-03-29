using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Repository.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlyMateAPI.Core.Repository
{
    public class TicketRepository : ITicketRepository
    {

        private IMongoCollection<Ticket> _ticketsCollection;

        public TicketRepository(IOptions<FlightsStoreDatabaseSettings> flightsStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(flightsStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(flightsStoreDatabaseSettings.Value.DatabaseName);
            _ticketsCollection = mongoDatabase.GetCollection<Ticket>(flightsStoreDatabaseSettings.Value.TicketCollectionName);
        }

        public async Task CreateAsync(Ticket newTicket) =>
            await _ticketsCollection.InsertOneAsync(newTicket);

        public async Task DeleteAsync(string id) =>
            await _ticketsCollection.DeleteOneAsync(x => x.Id == id);

        public async Task<List<Ticket>> GetAllAsync() =>
            await _ticketsCollection.Find(_ => true).ToListAsync();

        public async Task<Ticket?> GetbyIdAsync(string id) =>
            await _ticketsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Ticket updateTicket) =>
            await _ticketsCollection.ReplaceOneAsync(x => x.Id == id, updateTicket);
    }
}
