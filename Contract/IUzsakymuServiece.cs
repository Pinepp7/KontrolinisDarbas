using KontrolinisDarbas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Contract
{
    public interface IUzsakymuServiece
    {
        Task<Uzsakymas> GautiUzsakymaPagalId(int uzsakymoid);
        Task<IEnumerable<Uzsakymas>> GautiVisusUzsakymus();
        Task PridetiUzsakyma(Uzsakymas uzsakymas);
        Task AtnaujantiUzsakyma(Uzsakymas uzsakymas);
        Task IstrintiUzsakyma(int uzsakymoid);
    }
}
