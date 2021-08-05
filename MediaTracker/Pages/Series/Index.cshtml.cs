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
    public class IndexModel : ViewMediaModel<SeriesContext, Models.Series> {
        private readonly SeriesContext _context;

        public IndexModel(SeriesContext context) {
            _context = context;
        }

        public override IQueryable<Models.Series> ContextDatabase => _context.Series;

    }
}
