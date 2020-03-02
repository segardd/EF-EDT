using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Creneau
    {
        [JsonProperty]
        public string id { get; set; }
        [JsonProperty]
        public string title { get; set; }
        [JsonProperty]
        public DateTime start { get; set; }
        [JsonProperty]
        public DateTime end { get; set; }

        public Creneau() { }

        public Creneau(Cours cours)
        {
            this.id = cours.UEID.ToString();
            this.title = cours.LUE.NomComplet;
            this.start = cours.DHDebut;
            this.end = cours.DHFin;

        }


    }
}
