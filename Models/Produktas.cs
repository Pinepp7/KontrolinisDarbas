using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Models
{
    public class Produktas
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public decimal Kaina { get; set; }
        public string Kategorija { get; set; }
        public int Kiekis { get; set; }
    }
}
