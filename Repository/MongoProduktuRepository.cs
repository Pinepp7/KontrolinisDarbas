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
    public class MongoProduktuRepository : IProduktuDbRepository
    {
        private readonly IMongoCollection<Produktas> _produktai;
        public MongoProduktuRepository(MongoDbContext context)
        {
            _produktai = context.Produktai;
        }
        public async Task AtnaujantiProdukta(Produktas produktas)
        {
            var filter = Builders<Produktas>.Filter.Eq(p => p.Id, produktas.Id);
            await _produktai.ReplaceOneAsync(filter, produktas);
        }

        public async Task<Produktas> GautiProduktaPagalId(int produktoId)
        {
            return await _produktai.Find(p => p.Id == produktoId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produktas>> GautiVisusProduktus()
        {
            return await _produktai.Find(p => true).ToListAsync();
        }

        public async Task IstrintiProdukta(int produktoId)
        {
            var filter = Builders<Produktas>.Filter.Eq(p => p.Id, produktoId);
            await _produktai.DeleteOneAsync(filter);
        }

        public async Task PridetiProdukta(Produktas produktas)
        {
            await _produktai.InsertOneAsync(produktas);
        }
    }
}
