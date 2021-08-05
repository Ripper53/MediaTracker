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
    public class IndexModel : ViewMediaModel<MovieContext, Movie> {
        private readonly MovieContext _context;

        public IndexModel(MovieContext context) {
            _context = context;
        }

        public override IQueryable<Movie> ContextDatabase => _context.Movie;

    }
}
