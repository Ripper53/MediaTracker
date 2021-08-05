namespace MediaTracker.Models {
    public interface IMedia {
        public string Name { get; }
        public string Genre { get; }
        public string Review { get; }
    }
}
