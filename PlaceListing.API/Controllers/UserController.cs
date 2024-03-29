using Microsoft.AspNetCore.Mvc;
using PlaceListing.API.Core.Interfaces;
using PlaceListing.API.Core.Models.Users;

namespace PlaceListing.API.NET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase { 

        private readonly IAuthManager _authManager;
        private readonly ILogger<UserController> _logger;

        public UserController(IAuthManager authManager, ILogger<UserController> logger)
        {
            this._authManager = authManager;
            this._logger = logger;
        }

        // POST: api/User/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            _logger.LogInformation($"Register attempt for email: {apiUserDto.Email}");
            var errors = await _authManager.Register(apiUserDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok();
        }


        // POST: api/User/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            _logger.LogInformation($"Login attempt for email: {loginDto.Email}");
            var authResponse = await _authManager.Login(loginDto);

            if(authResponse == null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }


        // POST: api/User/refreshToken
        [HttpPost]
        [Route("refreshToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto authResponseDto)
        {
            _logger.LogInformation($"Refresh token process started for email: {authResponseDto.UserId}");
            var authResponse = await _authManager.VerifyRefreshToken(authResponseDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }
    }
}