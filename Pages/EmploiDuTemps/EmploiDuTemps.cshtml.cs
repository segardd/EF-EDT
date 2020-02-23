using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Pages.EmploiDuTemps
{
    
    public class EmploiDuTempsModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public EmploiDuTempsModel(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        
        public Dictionary<string, List<Creneau>> MesCrenos { get; set; }
    
        public async Task AddCreno(Universite.Models.UniversiteContext context, DateTime dateEDT)
        {
            MesCrenos = new Dictionary<string, List<Creneau>>();

            List<Cours> LesCrenos= new List<Cours>();
            DateTime borneInf = dateEDT;
            DateTime borneSup = dateEDT;
            int dayNumber= 0;

            switch(dateEDT.DayOfWeek){
                case DayOfWeek.Monday:
                    dayNumber = 1;
                    break;
                case DayOfWeek.Tuesday:
                    dayNumber = 2;
                    break;
                case DayOfWeek.Wednesday:
                    dayNumber = 3;
                    break;
                case DayOfWeek.Thursday:
                    dayNumber = 4;
                    break;
                case DayOfWeek.Friday:
                    dayNumber = 5;
                    break;
                case DayOfWeek.Saturday:
                    dayNumber = 6;
                    break;
                default:
                    break;
            }
            borneSup = borneSup.AddDays((7 - dayNumber));
            borneInf = borneInf.Subtract(TimeSpan.FromDays(dayNumber - 1));


            LesCrenos =await _context.Cours.Where(c=>c.DHDebut.Date <= borneInf && c.DHDebut <=borneSup).ToListAsync();

            if (LesCrenos.Count != 0)
            {

                List<Creneau> Monday = new List<Creneau>();
                List<Creneau> Tuesday = new List<Creneau>();
                List<Creneau> Wednesday = new List<Creneau>();
                List<Creneau> Thursday = new List<Creneau>();
                List<Creneau> Friday = new List<Creneau>();
                List<Creneau> Saturday = new List<Creneau>();






                foreach (Cours creno in LesCrenos)
                {
                    Creneau enCreno = new Creneau(creno, 8, 21);
                    switch (enCreno.DHDebut.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            Monday.Add(enCreno);
                            break;
                        case DayOfWeek.Tuesday:
                            Tuesday.Add(enCreno);
                            break;
                        case DayOfWeek.Wednesday:
                            Wednesday.Add(enCreno);
                            break;
                        case DayOfWeek.Thursday:
                            Thursday.Add(enCreno);
                            break;
                        case DayOfWeek.Friday:
                            Friday.Add(enCreno);
                            break;
                        case DayOfWeek.Saturday:
                            Saturday.Add(enCreno);
                            break;
                        default:
                            break;
                    }

                }

                MesCrenos.Add("Monday", Monday);
                MesCrenos.Add("Tuesday", Tuesday);
                MesCrenos.Add("Wednesday", Wednesday);
                MesCrenos.Add("Thursday", Thursday);
                MesCrenos.Add("Friday", Friday);
                MesCrenos.Add("Saturday", Saturday);
            }
           /* else
            {
                MesCrenos.Add("Monday", null);
                MesCrenos.Add("Tuesday", null);
                MesCrenos.Add("Wednesday", null);
                MesCrenos.Add("Thursday", null);
                MesCrenos.Add("Friday", null);
                MesCrenos.Add("Saturday", null);
            }*/

        }
        public async Task OnGet()
        {
            await AddCreno(_context, DateTime.Now);
        }

    }
}