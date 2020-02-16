using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Pages.Courss
{
    public class IndexModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public IndexModel(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        public IList<Cours> Cours { get;set; }

        public async Task OnGetAsync()
        {
            Cours = await _context.Cours
                .Include(c => c.LUE).ToListAsync();
        }
    }
}
