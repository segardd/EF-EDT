using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Pages.Courss
{
    public class EditModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public EditModel(Universite.Models.UniversiteContext context)
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
                .Include(c => c.LSalle)
                .Include(c => c.LUE).FirstOrDefaultAsync(m => m.CoursID == id);

            if (Cours == null)
            {
                return NotFound();
            }
           ViewData["SalleID"] = new SelectList(_context.Salle, "SalleID", "SalleID");
           ViewData["UEID"] = new SelectList(_context.UE, "ID", "Intitule");
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

            _context.Attach(Cours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursExists(Cours.CoursID))
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

        private bool CoursExists(int id)
        {
            return _context.Cours.Any(e => e.CoursID == id);
        }
    }
}
