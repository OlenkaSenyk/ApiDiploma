using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_diploma.Controllers
{
    [Route("parameters")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        public ParametersService _parametersService;

        public ParametersController(ParametersService parametersService)
        {
            _parametersService = parametersService;
        }
        /*
        [HttpGet]
        public IActionResult GetAllParameters()
        {
            return Ok(_parametersService.GetAllParameters());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetParametersById(int id)
        {
            return Ok(_parametersService.GetParameterById(id));
        }

        [HttpGet("people/{id}")]
        public IActionResult GetParametersByPersonId(int id)
        {
            return Ok(_parametersService.GetParametersByPersonId(id));
        }

        [HttpPost]
        public IActionResult AddParameter([FromBody] ParameterVM parameter)
        {
            _parametersService.AddParameter(parameter);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateParameterById(int id, [FromBody] ParameterVM parameter)
        {
            return Ok(_parametersService.UpdateParameterById(id, parameter));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteParameterById(int id)
        {
            _parametersService.DeleteParameterById(id);
            return Ok();
        }
        */
    }
}
