using KontrolinisDarbas.Contract;
using KontrolinisDarbas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Repository
{
   
    
    public class UzsakymuDbRepository : IUzsakymuDbRepository
    {
        private readonly AppDbContext _context;
        public UzsakymuDbRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AtnaujantiUzsakyma(Uzsakymas uzsakymas)
        {
           _context.Uzsakymas.Update(uzsakymas);
           await _context.SaveChangesAsync();
        }

        public async Task<Uzsakymas> GautiUzsakymaPagalId(int uzsakymoid)
        {
            return await _context.Uzsakymas
                 .Include(o => o.PirkejoId)
                 .Include(o => o.ProduktoId)
                 .FirstOrDefaultAsync(o => o.UzsakymoId == uzsakymoid);
        }

        public async Task<IEnumerable<Uzsakymas>> GautiVisusUzsakymus()
        {
            return await _context.Uzsakymas
                .Include(o => o.Pirkejas)
                .Include(o => o.Produktas)
                .ToListAsync();
        }

        public async Task IstrintiUzsakyma(int uzsakymoid)
        {
            var uzsakymas = await _context.Uzsakymas.FindAsync(uzsakymoid);
            if (uzsakymas != null)
            {
                _context.Uzsakymas.Remove(uzsakymas);
                await _context.SaveChangesAsync();
            } 
        }

        public async Task PridetiUzsakyma(Uzsakymas uzsakymas)
        {
            _context.Uzsakymas.Add(uzsakymas);
            await _context.SaveChangesAsync();
        }
    }
}
