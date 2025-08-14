using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_Minmal_API_Example.Models;

namespace MongoDB_Minmal_API_Example.Services
{
    public class GameService
    {
        private readonly IMongoCollection<Game> _gamesCollection;

        public GameService(IOptions<GameDatabaseSettings> gamesDatabaseSettings)
        {
            var mongoClient = new MongoClient(gamesDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(gamesDatabaseSettings.Value.DatabaseName);

            _gamesCollection = mongoDatabase.GetCollection<Game>(gamesDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Game>> GetAsync() =>
            await _gamesCollection.Find(_ => true).ToListAsync();

        public async Task<Game?> GetAsync(string id) =>
            await _gamesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Game newGame) =>
            await _gamesCollection.InsertOneAsync(newGame);

        public async Task UpdateAsync(string id, Game updatedGame) =>
            await _gamesCollection.ReplaceOneAsync(x => x.Id == id, updatedGame);

        public async Task RemoveAsync(string id) =>
            await _gamesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
