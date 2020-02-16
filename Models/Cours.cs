using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Cours
    {
        public int CoursID { get; set; }
        public string salle { get; set; }
        public DateTime DHDebut { get; set; }
        public DateTime DHFin { get; set; }
        public int? UEID { get; set; }

        public UE LUE { get; set; }

    }
}
