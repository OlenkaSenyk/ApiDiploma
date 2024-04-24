using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;

namespace api_diploma.Data.Services
{
    public class CombatParticipationsService
    {
        AppDbContext _context;
        public CombatParticipationsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddCombatParticipation(CombatParticipationVM combatParticipation)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == combatParticipation.PersonId);

            if (_person != null)
            {
                var _combatParticipation = new CombatParticipation()
                {
                    Location = combatParticipation.Location,
                    StartDate = combatParticipation.StartDate,
                    EndDate = combatParticipation.EndDate,
                    OperationType = combatParticipation.OperationType,
                    Person = _person
                };

                _context.CombatParticipation.Add(_combatParticipation);
                _context.SaveChanges();
            }
        }

        public List<CombatParticipation> GetAllCombatParticipations() => _context.CombatParticipation.ToList();

        public CombatParticipation GetCombatParticipationById(int id) => _context.CombatParticipation.FirstOrDefault(p => p.Id == id);

        public List<CombatParticipation> GetCombatParticipationByPersonId(int id) => _context.CombatParticipation.Where(p => p.PersonId == id).ToList();

        public CombatParticipation UpdateCombatParticipationById(int id, CombatParticipationVM combatParticipation)
        {
            var _combatParticipation = _context.CombatParticipation.FirstOrDefault(p => p.Id == id);

            if (_combatParticipation != null)
            {
                _combatParticipation.Location = combatParticipation.Location;
                _combatParticipation.StartDate = combatParticipation.StartDate;
                _combatParticipation.EndDate = combatParticipation.EndDate;
                _combatParticipation.OperationType = combatParticipation.OperationType;

                _context.SaveChanges();
            }

            return _combatParticipation;
        }

        public void DeleteCombarParticipationById(int id)
        {
            var _combatParticipation = _context.CombatParticipation.FirstOrDefault(p => p.Id == id);
            if (_combatParticipation != null)
            {
                _context.CombatParticipation.Remove(_combatParticipation);
                _context.SaveChanges();
            }
        }
    }
}
