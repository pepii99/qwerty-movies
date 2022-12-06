namespace QwertyAPI.Data.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ActorId { get; set; }

        public Actor Actor { get; set; }

        public IEnumerable<Movie> Movies { get; } = new HashSet<Movie>();
    }
}
