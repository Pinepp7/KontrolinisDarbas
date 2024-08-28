using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Models
{
    public class Uzsakymas
    {
        [Key]
        public int PirkejoId { get; set; }
        public int ProduktoId { get; set; }
        public int UzsakymoId { get; set; }
        public DateTime UzsakymoDate { get; set; }
        public int UzsakymoKiekis {  get; set; }

        public Pirkejas Pirkejas { get; set; }
        public Produktas Produktas { get; set; }
    }
}

