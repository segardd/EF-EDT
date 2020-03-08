
using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;

using Universite.Models;



namespace Universite.Pages.Exemples

{
    [Authorize(Roles = "Enseignant")]
    public class ExempleSelectModel : PageModel

    {

        private readonly Universite.Models.UniversiteContext _context;

        public ExempleSelectModel(Universite.Models.UniversiteContext context)

        {

            _context = context;

        }



        // Les données à afficher

        public IList<UE> LesUes { get; set; }

        // L’étudiant sélectionné

        [BindProperty]

        public int UeID { get; set; }
        [BindProperty]
        public int UeIDOld {get; set;}

        public Etudiant Etudiant { get; set; }
        public IList<Etudiant> LesEtudiants { get; set; }

        public IList<Note> LesNotes {get; set; }

        public IList<EtudiantUeNote> LesEtudiantUeNote { get; set; }

        [BindProperty]
        public int[] etudiantID { get; set; }
        [BindProperty]
        public string[] NoteValeur { get; set; }

        // Contenu de la combo box


        public List<SelectListItem> SelectEtudiantsData { get; private set; }

        public async Task SelectList()
        {
            LesUes = await _context.UE.ToListAsync();

            // Initialisation de la page. Chargement de la liste déroulante des Etudiants

            SelectEtudiantsData = new List<SelectListItem>();

            SelectEtudiantsData.Add(new SelectListItem

            {

                Text = "Choisir un UE",

                Value = ""

            });

            foreach (UE e in LesUes)

            {

                SelectEtudiantsData.Add(new SelectListItem

                {

                    Text = e.NomComplet,

                    Value = e.ID.ToString()

                });

            }

            

            // Remplissage de la vue

            ViewData["SelectUesData"] = new SelectList(SelectEtudiantsData, "Value", "Text");
        }

        public async Task ChargeEtudiantNotes()
        {
           
            LesEtudiants = new List<Etudiant>();
            LesEtudiantUeNote = new List<EtudiantUeNote>();
            UE ue =  _context.UE.Where(u => u.ID == UeID).First();
            // Formation LaFormation = await _context.Formation.FirstAsync(f => f.ID == ue.);


            LesEtudiants = await _context.Etudiant.Where(f => f.FormationID == ue.FormationID).Include(e => e.LesNotes).ToListAsync();
            foreach (Etudiant etu in LesEtudiants)
            {

                bool isNote = false;
                string NoteInter = "";
               
                try
                {
                    NoteInter = _context.Note.Where(n => n.UEID == ue.ID && n.EtudiantID == etu.ID).First().Valeur.ToString();
                    isNote = true;

                }
                catch
                {
                    
                }


                LesEtudiantUeNote.Add(new EtudiantUeNote
                {
                    UE = ue,
                    etudiant = etu,
                    note = NoteInter,
                    isNote = isNote


                });
            }
        }

            public async Task OnGetAsync()

        {
            
            await SelectList();

            

        }

        public async Task<IActionResult> OnPostAsync()
        {
            UeIDOld = UeID;

            await SelectList();
            await ChargeEtudiantNotes();
            if (!ModelState.IsValid)
            {
                //Console.WriteLine('invalid');
                return Page();
            }


           
           /* foreach(Etudiant etud in LesEtudiants)
            {
                if (etud.LesNotes.Count() == 0)
                {

                }
            }*/
            //ViewData["SelectUesData"] = new SelectList(SelectEtudiantsData, "Value", "Text");
            LesNotes = await _context.Note.ToListAsync();
            ViewData["LesEtudiants"] = LesEtudiants;
            return Page();
        }
        public async Task<IActionResult> OnPostNoteAsync()
        {
            await ChargeEtudiantNotes();
            if (!ModelState.IsValid)
            {
                return Page();
            }

           // _context.Attach(Etudiant).State = EntityState.Modified;

            /*try
            {
                if (LesNotes.Count()>0) {
                    foreach(var note in LesNotes)
                    {
                        _context.Note.Where(n => n.ID == note.ID).First().Valeur = note.Valeur;
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
                    throw;
                
            }*/

            if (etudiantID.Length >= 0)
            {
                for (int i =0; i < etudiantID.Length; i++)
                {
                    int NoteInt= System.Convert.ToInt32(NoteValeur[i]);
                    if (NoteValeur[i] == null)
                    {
                        // on supprime la note de la bdd
                        try
                        {
                            _context.Remove(_context.Note.Where(n => n.UEID == UeIDOld && n.EtudiantID == etudiantID[i]).First());
                        }
                        catch
                        {

                        }
                        
                        
                        await _context.SaveChangesAsync();


                    }
                    else
                    {
                        //on modifie
                        Note newNote = new Note { 
                        EtudiantID=etudiantID[i],
                        UEID=UeIDOld,
                        Valeur=NoteInt
                        };
                        try {
                            Note noteBD = _context.Note.Where(n => n.UEID == newNote.UEID && n.EtudiantID == newNote.EtudiantID).First();
                            noteBD.Valeur=newNote.Valeur;
                            //_context.Entry(noteBD).State = EntityState.Modified;


                        }
                        catch
                        {
                            _context.Note.Add(newNote);
                        }
                        await _context.SaveChangesAsync();
                        
                        
                    }
                }
                
            }

            return RedirectToPage("../Index");
        }

    }

}