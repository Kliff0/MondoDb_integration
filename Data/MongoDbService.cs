using System;
using DnsClient.Protocol;
using MongoDB.Driver;

namespace DLG.Data;

public class MongoDbService
{
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase? _database;
    public MongoDbService(IConfiguration configuration)
    {
        _configuration = configuration;

        var connectionString = _configuration.GetConnectionString("DbConnection");
        Console.WriteLine("Test1: " + connectionString);
        var mongoUrl = MongoUrl.Create(connectionString);
        Console.WriteLine("Test2: " + connectionString);
        var mongoClient = new MongoClient(mongoUrl);
        Console.WriteLine("Test3: " + connectionString);
        Console.WriteLine("Test4: " + mongoUrl.DatabaseName);
        _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
    }

    public IMongoDatabase? Database => _database;
}
