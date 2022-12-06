namespace QwertyAPI.Features.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MoviesAppAPI.Data.Models;
    using MoviesAppAPI.Features;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;

        public IdentityController(UserManager<User> userManager, IIdentityService userService)
        {
            this.userManager = userManager;
            this.identityService = userService;
        }

        //[Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = identityService.GetAll();
            return Ok(users);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginRequestModel model)
        {
            var response = identityService.Authenticate(model);

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
                Password = model.Password,
            };

            var result = await userManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }


        [Route(nameof(Login))]

        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            string token = identityService.GenerateJwtToken(user);
            
            return new LoginResponseModel
            {
                Token = token
            };

        }
    }
}
