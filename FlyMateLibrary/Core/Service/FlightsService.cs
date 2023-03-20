using FlyMateLibrary.Core.Model;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace FlyMateLibrary.Core.Serivce;

public class FlightsService
{
    private readonly IMongoCollection<Flight> _flightsCollection;

    public FlightsService(
        IOptions<FlightsStoreDatabaseSettings> flightsStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            flightsStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            flightsStoreDatabaseSettings.Value.DatabaseName);

        _flightsCollection = mongoDatabase.GetCollection<Flight>(
            flightsStoreDatabaseSettings.Value.FlightsCollectionName);
    }

    public async Task<List<Flight>> GetAsync() =>
        await _flightsCollection.Find(_ => true).ToListAsync();

    public async Task<Flight?> GetAsync(string id) =>
        await _flightsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Flight newFlight) =>
        await _flightsCollection.InsertOneAsync(newFlight);

    public async Task UpdateAsync(string id, Flight updateFlight) =>
        await _flightsCollection.ReplaceOneAsync(x => x.Id == id, updateFlight);

    public async Task RemoveAsync(string id) =>
        await _flightsCollection.DeleteOneAsync(x => x.Id == id);
}