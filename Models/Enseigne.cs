using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Enseigne
    {
        public int EnseigneID { get; set; }

        public int? EnseignantID { get; set; }

        public int? UEID { get; set; }

        public Enseignant LEnseignant { get; set; }

        public UE LUE { get; set; }

        public ICollection<Cours> LesCours { get; set; }
    }
}
