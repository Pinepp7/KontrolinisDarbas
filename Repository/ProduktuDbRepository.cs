using KontrolinisDarbas.Contract;
using KontrolinisDarbas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Repository
{
    public class ProduktuDbRepository : IProduktuDbRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProduktuDbRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task AtnaujantiProdukta(Produktas produktas)
        {
           _appDbContext.Produktas.Update(produktas);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Produktas> GautiProduktaPagalId(int produktoId)
        {
            return await _appDbContext.Produktas.FindAsync(produktoId);
        }

        public async Task<IEnumerable<Produktas>> GautiVisusProduktus()
        {
           return await _appDbContext.Produktas.ToListAsync();
        }

        public async Task IstrintiProdukta(int produktoId)
        {
           var user = await _appDbContext.Produktas.FindAsync(produktoId);
            if (user != null)
            {
                _appDbContext.Produktas.Remove(user);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task PridetiProdukta(Produktas produktas)
        {
            _appDbContext.Produktas.Add(produktas);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
