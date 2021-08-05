using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaTracker.Data;
using MediaTracker.Models;

namespace MediaTracker.Pages.Series
{
    public class DeleteModel : PageModel
    {
        private readonly MediaTracker.Data.SeriesContext _context;

        public DeleteModel(MediaTracker.Data.SeriesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Series Series { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Series = await _context.Series.FirstOrDefaultAsync(m => m.ID == id);

            if (Series == null)
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

            Series = await _context.Series.FindAsync(id);

            if (Series != null)
            {
                _context.Series.Remove(Series);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
