using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Pages.TypeCourss
{
    public class IndexModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public IndexModel(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        public IList<TypeCours> TypeCours { get;set; }

        public async Task OnGetAsync()
        {
            TypeCours = await _context.TypeCours.ToListAsync();
        }
    }
}
