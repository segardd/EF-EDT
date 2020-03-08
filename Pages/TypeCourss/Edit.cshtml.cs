using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Pages.TypeCourss
{
    public class EditModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public EditModel(Universite.Models.UniversiteContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TypeCours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCoursExists(TypeCours.TypeCoursID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TypeCoursExists(int id)
        {
            return _context.TypeCours.Any(e => e.TypeCoursID == id);
        }
    }
}
