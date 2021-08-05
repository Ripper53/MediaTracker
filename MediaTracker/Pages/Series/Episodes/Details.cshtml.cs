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
    public class DetailsModel : PageModel
    {
        private readonly MediaTracker.Data.EpisodeContext _context;

        public DetailsModel(MediaTracker.Data.EpisodeContext context)
        {
            _context = context;
        }

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
    }
}
