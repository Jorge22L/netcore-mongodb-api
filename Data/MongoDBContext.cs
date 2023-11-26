using api.Models;
using MongoDB.Driver;

namespace api.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<testQ> testQ => _database.GetCollection<testQ>("testQ");
    }
}
