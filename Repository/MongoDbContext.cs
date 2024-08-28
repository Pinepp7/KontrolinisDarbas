using KontrolinisDarbas.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Pirkejas> Pirkejas => _database.GetCollection<Pirkejas>("Pirkejai");
    public IMongoCollection<Produktas> Produktai => _database.GetCollection<Produktas>("Produktai");
    public IMongoCollection<Uzsakymas> Uzsakymai => _database.GetCollection<Uzsakymas>("Uzsakymai");
}