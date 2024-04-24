using api_diploma.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_diploma.Controllers
{
    [ApiController]
    public class GeneralController : ControllerBase
    {
        public GeneralService _generalService;

        public GeneralController(GeneralService generalService)
        {
            _generalService = generalService;
        }

        [Authorize]
        [HttpGet("general")]
        public IActionResult GetAllPeople()
        {
            return Ok(_generalService.GetFullInfo());
        }
    }
}
