using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaTracker.Data;
using MediaTracker.Models;

namespace MediaTracker.Pages.Series {
    public class DetailsModel : PageModel {
        private readonly MediaTracker.Data.SeriesContext _context;

        public DetailsModel(MediaTracker.Data.SeriesContext context) {
            _context = context;
        }

        public Models.Series Series { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            Series = await _context.Series.FirstOrDefaultAsync(m => m.ID == id);

            if (Series == null) {
                return NotFound();
            }
            if (Series.Episodes == null)
                Series.Episodes = new List<Episode>();
            return Page();
        }
    }
}
