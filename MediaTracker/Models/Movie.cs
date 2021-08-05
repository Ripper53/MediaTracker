namespace MediaTracker.Models {
    public class Movie : IMedia {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Review { get; set; }
    }
}
