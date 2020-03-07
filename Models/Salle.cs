using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Salle
    {
        public int SalleID { get; set; }
        public string NomSalle { get; set; }

        public ICollection<UE> LesUE { get; set; }

        public ICollection<Cours> LesCours { get; set; }

    }
}
