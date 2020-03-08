using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Pages.Courss
{
    [Authorize(Roles = "Enseignant")]
    public class DetailsModel : PageModel
    {
        
        private readonly Universite.Models.UniversiteContext _context;

        public DetailsModel(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        public Cours Cours { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cours = await _context.Cours
                .Include(c => c.LEnseigne).ThenInclude(e => e.LEnseignant)
                .Include(c => c.LEnseigne).ThenInclude(e => e.LUE)
                .Include(c => c.LSalle)
                .Include(c => c.LeGroupe)
                .Include(c => c.LeTypeCours).FirstOrDefaultAsync(m => m.CoursID == id);

            if (Cours == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
