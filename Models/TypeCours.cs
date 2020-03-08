using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class TypeCours
    {
        public int TypeCoursID { get; set; }

        public string Intitule { get; set; }

        public ICollection<Cours> LesCours { get; set; }
    }
}
