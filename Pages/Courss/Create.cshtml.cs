﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universite.Models;

namespace Universite.Pages.Courss
{
    public class CreateModel : PageModel
    {
        private readonly Universite.Models.UniversiteContext _context;

        public CreateModel(Universite.Models.UniversiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UEID"] = new SelectList(_context.UE, "ID", "Intitule");
            return Page();
        }

        [BindProperty]
        public Cours Cours { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cours.Add(Cours);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
