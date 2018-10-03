using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using Leaderboard.Models;

namespace Leaderboard
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Player> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;
        private readonly IMongoDatabase _database;
        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = mongoClient.GetDatabase("Game");
            _collection = _database.GetCollection<Player>("players");
            _bsonDocumentCollection = _database.GetCollection<BsonDocument>("players");
            
        }
        public async Task<Player> Create(Player player)
        {
            await _collection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player> DeletePlayer(Guid id)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            Player plr = await _collection.FindOneAndDeleteAsync(filter);
            return plr;
        }

        public async Task<Player[]> GetAll()
        {
            List<Player> players = await _collection.Find(new BsonDocument()).ToListAsync();
            var sort = Builders<Player>.Sort.Descending("Score");
            int limit = players.Count;
            var cursor = _collection.Find(_=>true).Sort(sort).Limit(limit);
            players = await cursor.ToListAsync();
            return players.ToArray();
        }

        public async Task<Player> GetPlayer(int placement)
        {
            List<Player> players = await _collection.Find(new BsonDocument()).ToListAsync();
            var sort = Builders<Player>.Sort.Descending("Score");
            int limit = players.Count;
            var cursor = _collection.Find(_=>true).Sort(sort).Limit(limit);
            players = await cursor.ToListAsync();
            return players[placement];
        }
        public async Task<Player> GetName(string name) {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("Name",name);
            return await _collection.Find(filter).FirstAsync();
        }
    }
}
