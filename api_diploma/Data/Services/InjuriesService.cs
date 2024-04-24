using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;

namespace api_diploma.Data.Services
{
    public class InjuriesService
    {
        AppDbContext _context;
        public InjuriesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddInjurie(InjurieVM injurie)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == injurie.PersonId);

            if (_person != null)
            {
                var _injurie = new Injurie()
                {
                    Location = injurie.Location,
                    Date = injurie.Date,
                    Type = injurie.Type,
                    MedicalAssistance = injurie.MedicalAssistance,
                    Notes = injurie.Notes,
                    Person = _person
                };

                _context.Injurie.Add(_injurie);
                _context.SaveChanges();
            }
        }

        public List<Injurie> GetAllInjuries() => _context.Injurie.ToList();

        public Injurie GetInjurieById(int id) => _context.Injurie.FirstOrDefault(p => p.Id == id);

        public List<Injurie> GetInjuriesByPersonId(int id) => _context.Injurie.Where(p => p.PersonId == id).ToList();

        public Injurie UpdateInjurieById(int id, InjurieVM injurie)
        {
            var _injurie = _context.Injurie.FirstOrDefault(p => p.Id == id);

            if (_injurie != null)
            {
                _injurie.Location = injurie.Location;
                _injurie.Date = injurie.Date;
                _injurie.Type = injurie.Type;
                _injurie.MedicalAssistance = injurie.MedicalAssistance;
                _injurie.Notes = injurie.Notes;

                _context.SaveChanges();
            }

            return _injurie;
        }

        public void DeleteInjurieById(int id)
        {
            var _injurie = _context.Injurie.FirstOrDefault(p => p.Id == id);
            if (_injurie != null)
            {
                _context.Injurie.Remove(_injurie);
                _context.SaveChanges();
            }
        }
    }
}
