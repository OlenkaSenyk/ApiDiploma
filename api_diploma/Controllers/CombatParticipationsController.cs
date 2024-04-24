using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_diploma.Controllers
{
    [Route("combat-participations")]
    [ApiController]
    public class CombatParticipationsController : ControllerBase
    {
        public CombatParticipationsService _combatParticipations;

        public CombatParticipationsController(CombatParticipationsService combatParticipations)
        {
            _combatParticipations = combatParticipations;
        }
        /*
        [HttpGet]
        public IActionResult GetAllCombatParticipations()
        {
            return Ok(_combatParticipations.GetAllCombatParticipations());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetCombatParticipationById(int id)
        {
            return Ok(_combatParticipations.GetCombatParticipationById(id));
        }

        [HttpGet("people/{id}")]
        public IActionResult GetCombatParticipationsByPersonId(int id)
        {
            return Ok(_combatParticipations.GetCombatParticipationByPersonId(id));
        }

        [HttpPost]
        public IActionResult AddCombatParticipation([FromBody] CombatParticipationVM combatParticipation)
        {
            _combatParticipations.AddCombatParticipation(combatParticipation);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCombatParticipationById(int id, [FromBody] CombatParticipationVM combatParticipation)
        {
            return Ok(_combatParticipations.UpdateCombatParticipationById(id, combatParticipation));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCombatParticipationById(int id)
        {
            _combatParticipations.DeleteCombarParticipationById(id);
            return Ok();
        }
        */
    }
}
