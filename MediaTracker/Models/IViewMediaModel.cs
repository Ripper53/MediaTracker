using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MediaTracker.Models {
    public interface IViewMediaModel {
        #region Filter
        public string Name { get; }
        public SelectList Genres { get; }
        public string Genre { get; }
        #endregion
        public IEnumerable<IMedia> Media { get; }
    }
}
