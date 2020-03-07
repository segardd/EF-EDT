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
        public int? UEID { get; set; }

        public int? SalleID { get; set; }

        public UE LUE { get; set; }
        public Salle LSalle { get; set; }

    }
}
