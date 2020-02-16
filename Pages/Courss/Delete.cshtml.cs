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
    public class DeleteModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public DeleteModel(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cours Cours { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cours = await _context.Cours
                .Include(c => c.LUE).FirstOrDefaultAsync(m => m.CoursID == id);

            if (Cours == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cours = await _context.Cours.FindAsync(id);

            if (Cours != null)
            {
                _context.Cours.Remove(Cours);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
