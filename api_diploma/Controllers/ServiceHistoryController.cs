using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_diploma.Controllers
{
    [Route("service-history")]
    [ApiController]
    public class ServiceHistoryController : ControllerBase
    {
        public ServiceHistoryService _historyService;

        public ServiceHistoryController(ServiceHistoryService historyService)
        {
            _historyService = historyService;
        }
        /*
        [HttpGet]
        public IActionResult GetAllServiceHistory()
        {
            return Ok(_historyService.GetAllServiceHistories());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetServiceHistoryById(int id)
        {
            return Ok(_historyService.GetSerciceHistoryById(id));
        }

        [HttpGet("people/{id}")]
        public IActionResult GetServiceHistoryByPersonId(int id)
        {
            return Ok(_historyService.GetServiceHistoryByPersonId(id));
        }

        [HttpPost]
        public IActionResult AddServiceHistory([FromBody] ServiceHistoryVM serviceHistory)
        {
            _historyService.AddServiceHistory(serviceHistory);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServiceHistoryById(int id, [FromBody] ServiceHistoryVM serviceHistory)
        {
            return Ok(_historyService.UpdateServiceHistoryById(id, serviceHistory));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteServiceHistoryById(int id)
        {
            _historyService.DeleteServiceHistoryById(id);
            return Ok();
        }
        */
    }
}
