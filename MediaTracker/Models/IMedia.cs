namespace MediaTracker.Models {
    public interface IMedia {
        public int ID { get; }
        public string Name { get; }
        public string Genre { get; }
        public string Review { get; }
    }
}
