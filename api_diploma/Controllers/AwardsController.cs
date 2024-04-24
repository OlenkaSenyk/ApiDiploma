using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_diploma.Controllers
{
    [Route("awards")]
    [ApiController]
    public class AwardsController : ControllerBase
    {
        public AwardsService _awardsService;

        public AwardsController(AwardsService awardsService)
        {
            _awardsService = awardsService;
        }
        /*
        [HttpGet]
        public IActionResult GetAllAwards()
        {
            return Ok(_awardsService.GetAllAwards());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetAwardById(int id)
        {
            return Ok(_awardsService.GetAwardById(id));
        }

        [HttpGet("people/{id}")]
        public IActionResult GetAwardsByPersonId(int id)
        {
            return Ok(_awardsService.GetAwardsByPersonId(id));
        }

        [HttpPost]
        public IActionResult AddAwards([FromBody] AwardVM award)
        {
            _awardsService.AddAward(award);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAwardById(int id, [FromBody] AwardVM address)
        {
            return Ok(_awardsService.UpdateAwardById(id, address));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAwardById(int id)
        {
            _awardsService.DeleteAwardById(id);
            return Ok();
        }
        */
    }
}
