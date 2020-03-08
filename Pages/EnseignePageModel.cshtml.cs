using Universite.Models;

//using Universite.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

using System.Linq;
using Universite.Pages.Enseignants;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Universite.Pages
{
    public class EnseignePageModel : PageModel

    {



        public List<CheckEnseigne> LesCheckEnseigne;

        public SelectList ListEnseigne (UniversiteContext context)
        {
            List<Enseigne> MesEnseignes = new List<Enseigne>();
            List<RenderEnseigne> MesREnseignes = new List<RenderEnseigne>();
            MesEnseignes = context.Enseigne.Include(e => e.LUE).Include(e => e.LEnseignant).ToList();
            foreach(Enseigne enseigne in MesEnseignes)
            {
                RenderEnseigne monRenderEns = new RenderEnseigne(enseigne);
                MesREnseignes.Add(monRenderEns);
            }
            return new SelectList(MesREnseignes, "EnseigneID", "Intitule");

        }

        public void AddEnseigne(UniversiteContext context, Enseignant enseignant)

        {

            var lesUE = context.UE;

            var lesEnseigne = new HashSet<int?>(enseignant.LesEnseigne.Select(c => c.UEID));

            LesCheckEnseigne = new List<CheckEnseigne>();

            foreach (var UE in lesUE)

            {

                LesCheckEnseigne.Add(new CheckEnseigne

                {

                    UEID = UE.ID,

                    NomComplet = UE.NomComplet,

                    IsCheck = lesEnseigne.Contains(UE.ID)

                });

            }

        }
        public void UpdateEnseigne(UniversiteContext context,

            string[] selectedUE, Enseignant enseignantAModifier)

        {

            if (selectedUE == null)

            {

                enseignantAModifier.LesEnseigne = new List<Enseigne>();

                return;

            }



            var selectedUEHS = new HashSet<string>(selectedUE);

            var enseigne = new HashSet<int>

                (enseignantAModifier.LesEnseigne.Select(c => c.LUE.ID));

            foreach (var ue in context.UE)

            {

                if (selectedUEHS.Contains(ue.ID.ToString()))

                {

                    if (!enseigne.Contains(ue.ID))

                    {

                        enseignantAModifier.LesEnseigne.Add(

                            new Enseigne

                            {

                                EnseignantID = enseignantAModifier.ID,

                                UEID = ue.ID

                            });

                    }

                }

                else

                {

                    if (enseigne.Contains(ue.ID))

                    {

                        Enseigne enseigneAEnlever

                            = enseignantAModifier

                                .LesEnseigne

                                .SingleOrDefault(i => i.UEID == ue.ID);

                        context.Remove(enseigneAEnlever);

                    }

                }

            }

        }
    }
}
