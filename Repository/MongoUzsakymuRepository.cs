using KontrolinisDarbas.Contract;
using KontrolinisDarbas.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Repository
{
    public  class MongoUzsakymuRepository : IUzsakymuDbRepository
    {
        private readonly IMongoCollection<Uzsakymas> _uzsakymai;
        public MongoUzsakymuRepository(MongoDbContext context)
        {
            _uzsakymai = context.Uzsakymai;
        }


        public async Task<Uzsakymas> GautiUzsakymaPagalId(int uzsakymoid)
        {
            return await _uzsakymai.Find(u => u.UzsakymoId == uzsakymoid).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Uzsakymas>> GautiVisusUzsakymus()
        {
            return await _uzsakymai.Find(u => true).ToListAsync();
        }

        public async Task PridetiUzsakyma(Uzsakymas uzsakymas)
        {
            await _uzsakymai.InsertOneAsync(uzsakymas);
        }

        public async Task AtnaujantiUzsakyma(Uzsakymas uzsakymas)
        {
            var filter = Builders<Uzsakymas>.Filter.Eq(u => u.UzsakymoId, uzsakymas.UzsakymoId);
            await _uzsakymai.ReplaceOneAsync(filter, uzsakymas);
        }

        public async Task IstrintiUzsakyma(int uzsakymoid)
        {
            var filter = Builders<Uzsakymas>.Filter.Eq(u => u.UzsakymoId,uzsakymoid);
            await _uzsakymai.DeleteOneAsync(filter);
        }

       

    }
}
