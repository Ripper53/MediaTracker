using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediaTracker.Data;
using MediaTracker.Models;

namespace MediaTracker.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MediaTracker.Data.MovieContext _context;

        public CreateModel(MediaTracker.Data.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Genres = new SelectList(Media.GetValues());
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public SelectList Genres { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
