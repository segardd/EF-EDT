using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Groupe
    {
        public int GroupeID { get; set; }

        public string NomGroupe { get; set; }

        public int? UEID { get; set; }

        public UE LUE { get; set; }

        public ICollection<Cours> LesCours { get; set; }

    }
}
