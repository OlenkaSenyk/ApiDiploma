using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;

namespace api_diploma.Data.Services
{
    public class ServiceHistoryService
    {
        AppDbContext _context;
        public ServiceHistoryService(AppDbContext context)
        {
            _context = context;
        }

        public void AddServiceHistory(ServiceHistoryVM serviceHistory)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == serviceHistory.PersonID);

            if (_person != null)
            {
                var _serviceHistory = new ServiceHistory()
                {
                    StartDate = serviceHistory.StartDate,
                    EndDate = serviceHistory.EndDate,
                    MilitaryBranch = serviceHistory.MilitaryBranch,
                    MilitaryCategory = serviceHistory.MilitaryCategory,
                    MilitaryRank = serviceHistory.MilitaryRank,
                    MilitaryUnit = serviceHistory.MilitaryUnit,
                    Person = _person
                };

                _context.ServiceHistory.Add(_serviceHistory);
                _context.SaveChanges();
            }
        }

        public List<ServiceHistory> GetAllServiceHistories() => _context.ServiceHistory.ToList();

        public ServiceHistory GetSerciceHistoryById(int id) => _context.ServiceHistory.FirstOrDefault(p => p.Id == id);

        public List<ServiceHistory> GetServiceHistoryByPersonId(int id) => _context.ServiceHistory.Where(p => p.PersonId == id).ToList();

        public ServiceHistory UpdateServiceHistoryById(int id, ServiceHistoryVM serviceHistory)
        {
            var _serviceHistory = _context.ServiceHistory.FirstOrDefault(p => p.Id == id);

            if (_serviceHistory != null)
            {
                _serviceHistory.StartDate = serviceHistory.StartDate;
                _serviceHistory.EndDate = serviceHistory.EndDate;
                _serviceHistory.MilitaryBranch = serviceHistory.MilitaryBranch;
                _serviceHistory.MilitaryRank = serviceHistory.MilitaryRank;
                _serviceHistory.MilitaryCategory = serviceHistory.MilitaryCategory;
                _serviceHistory.MilitaryUnit = serviceHistory.MilitaryUnit;

                _context.SaveChanges();
            }

            return _serviceHistory;
        }

        public void DeleteServiceHistoryById(int id)
        {
            var _serviceHistory = _context.ServiceHistory.FirstOrDefault(p => p.Id == id);
            if (_serviceHistory != null)
            {
                _context.ServiceHistory.Remove(_serviceHistory);
                _context.SaveChanges();
            }
        }
    }
}
