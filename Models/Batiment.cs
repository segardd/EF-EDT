using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Batiment
    {
        public int BatimentID { get; set; }
        public string NomBatiment { get; set; }

        public ICollection<Salle> LesSalles { get; set; }
    }
}
