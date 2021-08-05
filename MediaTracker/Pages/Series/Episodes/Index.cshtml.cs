using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaTracker.Data;
using MediaTracker.Models;

namespace MediaTracker.Pages.Series.Episodes {
    public class IndexModel : PageModel {
        private readonly MediaTracker.Data.EpisodeContext _context;

        public IndexModel(MediaTracker.Data.EpisodeContext context) {
            _context = context;
        }

        public IList<Episode> Episode { get; set; }

        public async Task OnGetAsync() {
            Episode = await _context.Episode.ToListAsync();
        }
    }
}
