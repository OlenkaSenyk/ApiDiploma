using api_diploma.Data;
using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api_diploma.Controllers
{
    [Route("users")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        protected APIResponse _apiResponse;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
            _apiResponse = new APIResponse();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestVM request)
        {
            var response = _loginService.Login(request);

            if (response.User == null || string.IsNullOrEmpty(response.Token))
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("Email or password is incorrect");
                return BadRequest(_apiResponse);
            }

            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = response;
            return Ok(_apiResponse);
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegistrationRequestVM request)
        {
            bool ifEmailUnique = _loginService.IsUniqueUser(request.Email);
            if (!ifEmailUnique)
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("Email already exist");
                return BadRequest(_apiResponse);
            }

            var user = _loginService.Register(request);
            if (user == null)
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("Something went wrong during registration");
                return BadRequest(_apiResponse);
            }

            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = user;
            return Ok(_apiResponse);
        }
    }
}
