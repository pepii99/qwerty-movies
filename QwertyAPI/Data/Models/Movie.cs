namespace QwertyAPI.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Character> Characters { get; } = new HashSet<Character>();
    }
}
