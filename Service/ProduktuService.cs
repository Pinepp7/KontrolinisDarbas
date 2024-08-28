using KontrolinisDarbas.Contract;
using KontrolinisDarbas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Service
{
    public class ProduktuService : IProduktuServiece
    {
        private readonly IProduktuDbRepository _produktuRepository;

        public ProduktuService(IProduktuDbRepository produktuRepository)
        {
            _produktuRepository= produktuRepository;
        }
        public async Task AtnaujantiProdukta(Produktas produktas)
        {
           await _produktuRepository.AtnaujantiProdukta(produktas);
        }

        public async Task<Produktas> GautiProduktaPagalId(int produktoId)
        {
           return await _produktuRepository.GautiProduktaPagalId(produktoId);
        }

        public async Task<IEnumerable<Produktas>> GautiVisusProduktus()
        {
            return await _produktuRepository.GautiVisusProduktus();
        }

        public async Task IstrintiProdukta(int produktoId)
        {
            await _produktuRepository.IstrintiProdukta(produktoId);
        }

        public async Task PridetiProdukta(Produktas produktas)
        {
            await _produktuRepository.PridetiProdukta(produktas);
        }
    }
}
