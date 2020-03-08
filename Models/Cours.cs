using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{

    [JsonObject(MemberSerialization.OptIn)]
    public class Cours
    {
        public int CoursID { get; set; }


        public DateTime DHDebut { get; set; }
        public DateTime DHFin { get; set; }
        public int? EnseigneID { get; set; }

        public int? SalleID { get; set; }

        public int? GroupeID { get; set; }

        public int? TypeCoursID { get; set; }


        public Groupe LeGroupe { get; set; }
        public Enseigne LEnseigne { get; set; }
        public Salle LSalle { get; set; }

        public TypeCours LeTypeCours { get; set; }

       
    }
}
