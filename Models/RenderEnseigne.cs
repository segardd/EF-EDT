using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class RenderEnseigne
    {
        public int EnseigneID { get; set; }
        public string Intitule { get; set; }
        

        public RenderEnseigne(Enseigne enseigne)
        {
            this.EnseigneID = enseigne.EnseigneID;
            this.Intitule = $"{enseigne.LEnseignant.Nom} {enseigne.LEnseignant.Prenom} - {enseigne.LUE.NomComplet}";
         
            
        }
    }
}
