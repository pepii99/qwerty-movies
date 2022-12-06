namespace QwertyAPI.Data.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CharacterId { get; set; }

        public Character Character { get; set; }

        public string ImageUrl { get; set; }

    }
}
