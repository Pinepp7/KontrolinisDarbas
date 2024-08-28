using KontrolinisDarbas.Contract;
using KontrolinisDarbas.Models;
using Serilog;

namespace KontrolinisDarbas.Service
{
    public class PirkejuService : IPirkejuService
    {
        private readonly IPirkejuDbRepository _pirkejuRepository;
        private List<string> Pirkejas {  get; set; }
        public PirkejuService()
        {
            Pirkejas = new List<string>();
            Log.Information("Pirkeju service stardet");
        }

        public PirkejuService(IPirkejuDbRepository pirkejuRepository)
        {
            _pirkejuRepository = pirkejuRepository;
        }
        public async Task AtnaujantiPirkeja(Pirkejas pirkejas)
        {
           await _pirkejuRepository.AtnaujantiPirkeja(pirkejas);
        }

        public async Task<Pirkejas> GautiPirkejaPagalId(int pirkejoId)
        {
            return await _pirkejuRepository.GautiPirkejaPagalId(pirkejoId);
        }

        public async Task<IEnumerable<Pirkejas>> GautiVisusPirkejus()
        {
            return await _pirkejuRepository.GautiVisusPirkejus();
        }

        public async Task IstrintiPirkeja(int pirkejoId)
        {
            await _pirkejuRepository.IstrintiPirkeja(pirkejoId);
        }

        public async Task PridetiPirkeja(Pirkejas pirkejas)
        {
            await _pirkejuRepository.PridetiPirkeja(pirkejas);
        }
    }
}
