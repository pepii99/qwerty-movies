namespace MoviesAppAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MoviesAppAPI.Helpers;

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Works");
        }
    }
}