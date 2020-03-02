using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        DateTime dateVue { get; set; }
        [BindProperty]
        public List<Creneau> MesCrenos { get; set; }
    
       

        



        public async Task OnGet(bool increment=false)

        {
           
        }

        


    }
}