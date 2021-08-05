using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediaTracker.Models {
    public abstract class ViewMediaModel<TContext, TMedia> : PageModel, IViewMediaModel where TContext : DbContext where TMedia : IMedia {
        #region Filter
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Genre { get; set; }
        #endregion

        public IList<TMedia> Media { get; set; }
        IEnumerable<IMedia> IViewMediaModel.Media => (IEnumerable<IMedia>)Media;

        public abstract IQueryable<TMedia> ContextDatabase { get; }

        public async Task OnGetAsync() {
            Genres = new SelectList(Models.Media.GetValues(), Genre);

            IQueryable<TMedia> medias = ContextDatabase;

            if (!string.IsNullOrWhiteSpace(Name)) {
                medias = from m in medias
                         where m.Name.Contains(Name)
                         select m;
            }

            if (!string.IsNullOrWhiteSpace(Genre)) {
                medias = from m in medias
                         where m.Genre == Genre
                         select m;
            }

            Media = await medias.ToListAsync();
        }

    }
}
