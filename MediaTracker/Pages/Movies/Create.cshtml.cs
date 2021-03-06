using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediaTracker.Data;
using MediaTracker.Models;

namespace MediaTracker.Pages.Movies {
    public class CreateModel : InspectMediaModel<Movie> {
        private readonly MovieContext _context;

        public CreateModel(MovieContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Movie.Add(Media);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
