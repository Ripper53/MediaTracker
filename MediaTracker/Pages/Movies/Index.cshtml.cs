using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaTracker.Data;
using MediaTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediaTracker.Pages.Movies {
    public class IndexModel : PageModel {
        private readonly MediaTracker.Data.MovieContext _context;

        public IndexModel(MediaTracker.Data.MovieContext context) {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }

        #region Filter
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Genre { get; set; }
        #endregion

        public async Task OnGetAsync() {
            Genres = new SelectList(Media.GetValues(), Genre);

            IQueryable<Movie> movies = _context.Movie;

            if (!string.IsNullOrWhiteSpace(Name)) {
                movies = from m in movies
                         where m.Name.Contains(Name)
                         select m;
            }

            if (!string.IsNullOrWhiteSpace(Genre)) {
                movies = from m in movies
                         where m.Genre == Genre
                         select m;
            }

            Movie = await movies.ToListAsync();
        }

    }
}
