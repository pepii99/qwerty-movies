namespace QwertyAPI.Features.Identity
{
    using MoviesAppAPI.Data.Models;


    public class AuthenticateResponse
    {
        public Guid Guid { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Guid = user.Guid;
            UserName = user.UserName;
            Email = user.Email;
            Token = token;
        }
    }
}
