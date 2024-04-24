using api_diploma.Data;
using api_diploma.Data.Models;
using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api_diploma.Controllers
{
    [Route("people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private PeopleService _peopleService;
        protected APIResponse _apiResponse;

        public PeopleController(PeopleService peopleService)
        {
            _peopleService = peopleService;
            _apiResponse = new APIResponse();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var response = _peopleService.GetAllPeople();
            
            if (response == null)
            {
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("People not found");
                return NotFound(_apiResponse);
            }

            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = response;
            return Ok(_apiResponse);
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var response = _peopleService.GetPersonById(id);

            if (response == null)
            {
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("Person not found");
                return NotFound(_apiResponse);
            }

            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = response;
            return Ok(_apiResponse);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddPerson([FromBody]PersonVM person)
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            int userId = TokenHelper.GetClaimsFromToken(token);

            if (userId == -1)
            {
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("User not found");
                return NotFound(_apiResponse);
            }

            _peopleService.AddPerson(person, userId);
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            return Ok(_apiResponse);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{personId}")]
        public IActionResult UpdatePersonById(int personId, [FromBody]PersonVM person)
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            int userId = TokenHelper.GetClaimsFromToken(token);

            if (userId == -1)
            {
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("User not found");
                return NotFound(_apiResponse);
            }

            var _person = _peopleService.GetPersonById(personId);
            if (_person == null)
            {
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("Person not found");
                return NotFound(_apiResponse);
            }

            var response = _peopleService.UpdatePersonById(personId, person, userId);
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = response;
            return Ok(_apiResponse);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{personId}")]
        public IActionResult DeletePersonById(int personId)
        {
            var _person = _peopleService.GetPersonById(personId);
            if (_person == null)
            {
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMsgs.Add("Person not found");
                return NotFound(_apiResponse);
            }
            _peopleService.DeletePersonById(personId);
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            return Ok(_apiResponse);
        }
    }
}
