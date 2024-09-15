using AppDbApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppDbApi.Services;

public class FAQService
{
    private readonly IMongoCollection<FAQ> _FAQCollection;

    public FAQService(
        IOptions<AppDatabaseSettings> AppDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            AppDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            AppDatabaseSettings.Value.DatabaseName);

        _FAQCollection = mongoDatabase.GetCollection<FAQ>(
            AppDatabaseSettings.Value.FAQCollectionName);
    }

    public async Task<List<FAQ>> GetAsync() =>
        await _FAQCollection.Find(_ => true).ToListAsync();

    public async Task<FAQ?> GetAsync(string id) =>
        await _FAQCollection.Find(x => x._id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(FAQ newFAQ) =>
        await _FAQCollection.InsertOneAsync(newFAQ);

    public async Task UpdateAsync(string id, FAQ updatedFAQ) =>
        await _FAQCollection.ReplaceOneAsync(x => x._id == id, updatedFAQ);

    public async Task RemoveAsync(string id) =>
        await _FAQCollection.DeleteOneAsync(x => x._id == id);
}