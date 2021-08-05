using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediaTracker.Models {
    public interface IInspectMediaModel {
        public IMedia Media { get; }
        public SelectList Genres { get; }
    }
}
