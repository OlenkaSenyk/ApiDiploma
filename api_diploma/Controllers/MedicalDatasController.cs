using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_diploma.Controllers
{
    [Route("medical-datas")]
    [ApiController]
    public class MedicalDatasController : ControllerBase
    {
        public MedicalDatasService _medicalDatasService;

        public MedicalDatasController(MedicalDatasService medicalDatasService)
        {
            _medicalDatasService = medicalDatasService;
        }
        /*
        [HttpGet]
        public IActionResult GetAllMedicalDatas()
        {
            return Ok(_medicalDatasService.GetAllMedicalDatas());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetMedicalDataById(int id)
        {
            return Ok(_medicalDatasService.GetMedicalDataById(id));
        }

        [HttpGet("people/{id}")]
        public IActionResult GetMedicalDatasByPersonId(int id)
        {
            return Ok(_medicalDatasService.GetMedicalDataByPersonId(id));
        }

        [HttpPost]
        public IActionResult AddMedicalData([FromBody] MedicalDataVM medicalData)
        {
            _medicalDatasService.AddMedicalData(medicalData);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMedicalDataById(int id, [FromBody] MedicalDataVM medicalData)
        {
            return Ok(_medicalDatasService.UpdateMedicalDataById(id, medicalData));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMedicalDataById(int id)
        {
            _medicalDatasService.DeleteMedicalDataById(id);
            return Ok();
        }
        */
    }
}
