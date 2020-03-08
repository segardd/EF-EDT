using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class UE
    {
        // Clé primaire

        public int ID { get; set; }

        [Required]

        public string Numero { get; set; }

        [Required]

        public string Intitule { get; set; }



        // Clé étrangère vers la formation

        public int FormationID { get; set; }

        //[Display(Name = "UEs enseignées")]
        public string NomComplet

        {

            get

            {

                return Numero + " - " + Intitule;

            }

        }



        // Liens de navigation

        public Formation LaFormation { get; set; }

        public ICollection<Groupe> LesGroupes { get; set; }

        public ICollection<Note> LesNotes { get; set; }

        public ICollection<Enseigne> LesEnseigne { get; set; }

        
    }
}
