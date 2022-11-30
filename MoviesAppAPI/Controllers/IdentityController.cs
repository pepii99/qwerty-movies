namespace MoviesAppAPI.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MoviesAppAPI.Data.Models;
    using MoviesAppAPI.Models.Identity;
    using MoviesAppAPI.Services.Contracts;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public IdentityController(UserManager<User> userManager, IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        //[Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = userService.GetAll();
            return Ok(users);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginRequestModel model)
        {
            var response = userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password= model.Password,
            };

            

            var result = await this.userManager.CreateAsync(user, user.Password);
            

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }


        [Route(nameof(Login))]

        public async Task<ActionResult<string>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);

            if(user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

           return userService.generateJwtToken(user);

        }
    }
}
