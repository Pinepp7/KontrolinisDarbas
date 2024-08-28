using KontrolinisDarbas.Contract;
using KontrolinisDarbas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Service
{
    public class UzsakymuServiece : IUzsakymuServiece
    {
        private readonly IUzsakymuDbRepository _uzsakymoService;

        public UzsakymuServiece(IUzsakymuDbRepository uzsakymoReposytory)
        {
            _uzsakymoService = uzsakymoReposytory;
        }
        public async Task AtnaujantiUzsakyma(Uzsakymas uzsakymas)
        {
            await _uzsakymoService.AtnaujantiUzsakyma(uzsakymas);
        }

        public async Task<Uzsakymas> GautiUzsakymaPagalId(int uzsakymoid)
        {
            return await _uzsakymoService.GautiUzsakymaPagalId(uzsakymoid);
        }

        public async Task<IEnumerable<Uzsakymas>> GautiVisusUzsakymus()
        {
            return await _uzsakymoService.GautiVisusUzsakymus();
        }

        public async Task IstrintiUzsakyma(int uzsakymoid)
        {
            await _uzsakymoService.IstrintiUzsakyma(uzsakymoid);
        }

        public async Task PridetiUzsakyma(Uzsakymas uzsakymas)
        {
            await _uzsakymoService.PridetiUzsakyma(uzsakymas);
        }
    }
}
