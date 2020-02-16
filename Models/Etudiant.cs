using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Etudiant
    {
        public enum EnumGenre

        {

            Feminin, Masculin

        }
        public int ID { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }

        [Display(Name = "Date naissance")]

        [DataType(DataType.Date)]
        public DateTime Naissance { get; set; }

        //[RegularExpression(@"^[fm]*$")]
        [Required]
        public EnumGenre Genre { get; set; }
      
        [Display(Name = "Formation en cours")]
        public int ? FormationID { get; set; }

        // Lien de navigation vers les notes de l'étudiant

        public ICollection<Note> LesNotes { get; set; }

        public Formation LaFormation { get; set; }
    }
}
