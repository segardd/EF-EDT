using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class EtudiantUeNote
    {
        public Etudiant etudiant { get; set; }
        public UE UE { get; set; }
        //public Note note { get; set; }*

        [RegularExpression (@"[0-2]{1}[0-9]{1}\.[0-9]{0,2}$")]
        public string note { get; set; }

        public bool isNote { get; set; }


    }
}
