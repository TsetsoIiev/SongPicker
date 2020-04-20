namespace SongPicker.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SongPicker.Services.Models;
    using SongPicker.Services.Interfaces;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;
        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("api/login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Login(UserLogin model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var result = userService.Login(model);

            return result ? (IActionResult)Ok(result) : BadRequest();
        }

        [HttpPost]
        [Route("api/createUser")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Create(UserCreate model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var result = userService.CreateUser(model);

            return result ? (IActionResult)Ok(result) : BadRequest();
        }

        [HttpGet]
        [Route("api/user/{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Get(string username)
        {
            return Ok();
        }
    }
}