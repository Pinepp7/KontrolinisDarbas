using KontrolinisDarbas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Contract
{
    public interface IPirkejuDbRepository
    {
        Task<IEnumerable<Pirkejas>> GautiVisusPirkejus();
        Task<Pirkejas> GautiPirkejaPagalId(int pirkejoId);
        Task PridetiPirkeja(Pirkejas pirkejas);
        Task AtnaujantiPirkeja(Pirkejas pirkejas);
        Task IstrintiPirkeja(int pirkejoId);
    }
}
