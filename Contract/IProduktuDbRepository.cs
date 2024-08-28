using KontrolinisDarbas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Contract
{
    public interface IProduktuDbRepository
    {
        Task<Produktas> GautiProduktaPagalId(int produktoId);
        Task PridetiProdukta(Produktas produktas);
        Task<IEnumerable<Produktas>> GautiVisusProduktus();
        Task AtnaujantiProdukta(Produktas produktas);
        Task IstrintiProdukta(int produktoId);
    }
}
