using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediaTracker.Data;
using MediaTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MediaTracker.Pages.Series.Episodes {
    public class CreateModel : InspectMediaModel<Episode> {
        private readonly EpisodeContext _context;

        public CreateModel(EpisodeContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            ConfigurationManager.ConnectionStrings
            using (SeriesContext seriesContext = new SeriesContext(new DbContextOptionsBuilder<SeriesContext>().UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=SeriesContext-4c8b1ac0-f706-43ea-9bc5-6299fba05d2d;Trusted_Connection=True;MultipleActiveResultSets=true").Options)) {
                Models.Series series = await seriesContext.Series.FindAsync(0);
                series.Episodes.Add(Media);
                //seriesContext.Series.Update(series);
                await seriesContext.SaveChangesAsync();
            }

            _context.Episode.Add(Media);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }

    }
}
