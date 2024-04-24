using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;

namespace api_diploma.Data.Services
{
    public class MedicalDatasService
    {
        AppDbContext _context;
        public MedicalDatasService(AppDbContext context)
        {
            _context = context;
        }

        public void AddMedicalData(MedicalDataVM medicalData)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == medicalData.PersonId);

            if (_person != null)
            {
                var _medicalData = new MedicalData()
                {
                    BloodType = medicalData.BloodType,
                    BloodRh = medicalData.BloodRh,
                    Eligibility = medicalData.Eligibility,
                    Features = medicalData.Features,
                    Notes = medicalData.Notes,
                    Person = _person
                };

                _context.MedicalData.Add(_medicalData);
                _context.SaveChanges();
            }
        }

        public List<MedicalData> GetAllMedicalDatas() => _context.MedicalData.ToList();

        public MedicalData GetMedicalDataById(int id) => _context.MedicalData.FirstOrDefault(p => p.Id == id);

        public List<MedicalData> GetMedicalDataByPersonId(int id) => _context.MedicalData.Where(p => p.PersonId == id).ToList();

        public MedicalData UpdateMedicalDataById(int id, MedicalDataVM medicalData)
        {
            var _medicalData = _context.MedicalData.FirstOrDefault(p => p.Id == id);

            if (_medicalData != null)
            {
                _medicalData.BloodType = medicalData.BloodType;
                _medicalData.BloodRh = medicalData.BloodRh;
                _medicalData.Eligibility = medicalData.Eligibility;
                _medicalData.Features = medicalData.Features;
                _medicalData.Notes = medicalData.Notes;

                _context.SaveChanges();
            }

            return _medicalData;
        }

        public void DeleteMedicalDataById(int id)
        {
            var _medicalData = _context.MedicalData.FirstOrDefault(p => p.Id == id);
            if (_medicalData != null)
            {
                _context.MedicalData.Remove(_medicalData);
                _context.SaveChanges();
            }
        }
    }
}
