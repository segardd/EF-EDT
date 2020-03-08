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
    public class DeleteModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public DeleteModel(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypeCours TypeCours { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeCours = await _context.TypeCours.FirstOrDefaultAsync(m => m.TypeCoursID == id);

            if (TypeCours == null)
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

            TypeCours = await _context.TypeCours.FindAsync(id);

            if (TypeCours != null)
            {
                _context.TypeCours.Remove(TypeCours);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
