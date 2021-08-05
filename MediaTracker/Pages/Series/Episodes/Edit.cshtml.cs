using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediaTracker.Data;
using MediaTracker.Models;

namespace MediaTracker.Pages.Series.Episodes {
    public class EditModel : InspectMediaModel<Episode> {
        private readonly EpisodeContext _context;

        public EditModel(EpisodeContext context) {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            Media = await _context.Episode.FirstOrDefaultAsync(m => m.ID == id);

            if (Media == null) {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Media).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!EpisodeExists(Media.ID)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EpisodeExists(int id) {
            return _context.Episode.Any(e => e.ID == id);
        }

    }
}
