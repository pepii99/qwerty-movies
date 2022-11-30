namespace MoviesAppAPI.Services.Contracts
{
    using MoviesAppAPI.Data.Models;
    using MoviesAppAPI.Models.Identity;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(LoginRequestModel model);

        IEnumerable<User> GetAll();

        User GetById(string guid);

        string generateJwtToken(User user);

    }
}
