using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_diploma.Controllers
{
    [Route("injuries")]
    [ApiController]
    public class InjuriesController : ControllerBase
    {
        public InjuriesService _injuriesService;

        public InjuriesController(InjuriesService injuriesService)
        {
            _injuriesService = injuriesService;
        }
        /*
        [HttpGet]
        public IActionResult GetAllInjuries()
        {
            return Ok(_injuriesService.GetAllInjuries());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetInjurieById(int id)
        {
            return Ok(_injuriesService.GetInjurieById(id));
        }

        [HttpGet("people/{id}")]
        public IActionResult GetInjuriesByPersonId(int id)
        {
            return Ok(_injuriesService.GetInjuriesByPersonId(id));
        }

        [HttpPost]
        public IActionResult AddInjurie([FromBody] InjurieVM injurie)
        {
            _injuriesService.AddInjurie(injurie);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInjurieById(int id, [FromBody] InjurieVM injurie)
        {
            return Ok(_injuriesService.UpdateInjurieById(id, injurie));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInjurieById(int id)
        {
            _injuriesService.DeleteInjurieById(id);
            return Ok();
        }
        */
    }
}
