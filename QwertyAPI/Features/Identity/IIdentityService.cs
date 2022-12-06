namespace QwertyAPI.Features.Identity
{
    using MoviesAppAPI.Data.Models;

    public interface IIdentityService
    {
        AuthenticateResponse Authenticate(LoginRequestModel model);

        IEnumerable<User> GetAll();

        User GetById(string guid);

        string GenerateJwtToken(User user);

    }
}
