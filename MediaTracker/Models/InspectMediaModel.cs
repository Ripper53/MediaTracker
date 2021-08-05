using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediaTracker.Models {
    public abstract class InspectMediaModel<T> : PageModel, IInspectMediaModel where T : IMedia {
        [BindProperty]
        public T Media { get; set; }
        IMedia IInspectMediaModel.Media => Media;

        public InspectMediaModel() {
            Genres = new SelectList(Models.Media.GetValues());
        }

        public SelectList Genres { get; set; }

    }
}
