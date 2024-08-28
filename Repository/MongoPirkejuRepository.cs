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
    public class MongoPirkejuRepository : IPirkejuDbRepository
    {
        private readonly IMongoCollection<Pirkejas> _pirkejai;
        public MongoPirkejuRepository(MongoDbContext context)
        {
            _pirkejai = context.Pirkejas;
        }


        public async Task AtnaujantiPirkeja(Pirkejas pirkejas)
        {
            var filter = Builders<Pirkejas>.Filter.Eq(p => p.Id, pirkejas.Id);
            await _pirkejai.ReplaceOneAsync(filter, pirkejas);
        }
      
        public async Task<Pirkejas> GautiPirkejaPagalId(int pirkejoId)
        {
            return await _pirkejai.Find(p => p.Id == pirkejoId).FirstOrDefaultAsync();
        }
         
        public async Task<IEnumerable<Pirkejas>> GautiVisusPirkejus()
        {
            return await _pirkejai.Find(p=> true).ToListAsync();
        }
       
        public async Task IstrintiPirkeja(int pirkejoId)
        {
            var filter = Builders<Pirkejas>.Filter.Eq(p => p.Id, pirkejoId);
            await _pirkejai.DeleteOneAsync(filter);
        }
       
        public async Task PridetiPirkeja(Pirkejas pirkejas)
        {
            await _pirkejai.InsertOneAsync(pirkejas);
        }
    }
}
