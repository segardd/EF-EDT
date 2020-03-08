using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Pages.Groupes
{
    public class DeleteModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public DeleteModel(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Groupe Groupe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Groupe = await _context.Groupe
                .Include(g => g.LUE).FirstOrDefaultAsync(m => m.GroupeID == id);

            if (Groupe == null)
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

            Groupe = await _context.Groupe.FindAsync(id);

            if (Groupe != null)
            {
                _context.Groupe.Remove(Groupe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
