using System.Collections.Generic;

namespace MediaTracker.Models {
    public class Series : IMedia {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Review { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
