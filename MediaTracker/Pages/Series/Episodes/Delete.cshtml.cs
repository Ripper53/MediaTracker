using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaTracker.Data;
using MediaTracker.Models;

namespace MediaTracker.Pages.Series.Episodes
{
    public class DeleteModel : PageModel
    {
        private readonly MediaTracker.Data.EpisodeContext _context;

        public DeleteModel(MediaTracker.Data.EpisodeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Episode Episode { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Episode = await _context.Episode.FirstOrDefaultAsync(m => m.ID == id);

            if (Episode == null)
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

            Episode = await _context.Episode.FindAsync(id);

            if (Episode != null)
            {
                _context.Episode.Remove(Episode);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
