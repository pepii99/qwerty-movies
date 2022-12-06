namespace MoviesAppAPI.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using QwertyAPI.Data.Models;
    using System.Text.Json.Serialization;

    public class User : IdentityUser
    {
        public Guid Guid { get; set; }

        public override string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<Movie> Movies { get; } = new HashSet<Movie>();
    }
}
