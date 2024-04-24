using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;
using System.Drawing.Imaging;

namespace api_diploma.Data.Services
{
    public class AwardsService
    {
        AppDbContext _context;
        public AwardsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAward(AwardVM award)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == award.PersonId);

            if (_person != null )
            {
                var _award = new Award()
                {
                    Name = award.Name,
                    Date = award.Date,
                    Reason = award.Reason,
                    Person = _person
                };

                _context.Awards.Add(_award);
                _context.SaveChanges();
            }
        }

        public List<Award> GetAllAwards() => _context.Awards.ToList();

        public Award GetAwardById(int id) => _context.Awards.FirstOrDefault(p => p.Id == id);

        public List<Award> GetAwardsByPersonId(int id) => _context.Awards.Where(p => p.PersonId == id).ToList();
        
        public Award UpdateAwardById(int id, AwardVM award)
        {
            var _award = _context.Awards.FirstOrDefault(p => p.Id == id);

            if (_award != null)
            {
                _award.Name = award.Name;
                _award.Date = award.Date;
                _award.Reason = award.Reason;

                _context.SaveChanges();
            }

            return _award;
        }
      
        public void DeleteAwardById(int id)
        {
            var _award = _context.Awards.FirstOrDefault(p => p.Id == id);
            if (_award != null)
            {
                _context.Awards.Remove(_award);
                _context.SaveChanges();
            }
        }
    }
}
