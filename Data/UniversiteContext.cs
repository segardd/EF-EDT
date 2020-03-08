using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Models
{
    public class UniversiteContext : IdentityDbContext
    {
        public UniversiteContext(DbContextOptions<UniversiteContext> options)
            : base(options)
        {
        }
        public DbSet<Universite.Models.Etudiant> Etudiant { get; set; }

        public DbSet<Universite.Models.Enseignant> Enseignant { get; set; }

        public DbSet<Universite.Models.Enseigne> Enseigne { get; set; }

        public DbSet<Universite.Models.Formation> Formation { get; set; }

        public DbSet<Universite.Models.UE> UE { get; set; }

        public DbSet<Universite.Models.Note> Note { get; set; }

        public DbSet<Universite.Models.Cours> Cours { get; set; }

        public DbSet<Universite.Models.Salle> Salle { get; set; }

        public DbSet<Universite.Models.Groupe> Groupe { get; set; }

        public DbSet<Universite.Models.Batiment> Batiment { get; set; }

        public DbSet<Universite.Models.TypeCours> TypeCours { get; set; }



        

    }
}
