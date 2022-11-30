namespace MoviesAppAPI.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Text.Json.Serialization;

    public class User : IdentityUser
    {
        public Guid Guid { get; set; }

        public override string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
