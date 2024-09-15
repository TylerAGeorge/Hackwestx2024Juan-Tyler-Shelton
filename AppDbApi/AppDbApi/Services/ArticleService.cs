using AppDb.Models;
using AppDbApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppDbApi.Services;

public class ArticleService
{
    private readonly IMongoCollection<Article> _ArticleCollection;

    public ArticleService(
        IOptions<AppDatabaseSettings> AppDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            AppDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            AppDatabaseSettings.Value.DatabaseName);

        _ArticleCollection = mongoDatabase.GetCollection<Article>(
            AppDatabaseSettings.Value.ArticleCollectionName);
    }

    public async Task<List<Article>> GetAsync() =>
        await _ArticleCollection.Find(_ => true).ToListAsync();

    public async Task<Article?> GetAsync(string id) =>
        await _ArticleCollection.Find(x => x._id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Article newArticle) =>
        await _ArticleCollection.InsertOneAsync(newArticle);

    public async Task UpdateAsync(string id, Article updatedArticle) =>
        await _ArticleCollection.ReplaceOneAsync(x => x._id == id, updatedArticle);

    public async Task RemoveAsync(string id) =>
        await _ArticleCollection.DeleteOneAsync(x => x._id == id);
}