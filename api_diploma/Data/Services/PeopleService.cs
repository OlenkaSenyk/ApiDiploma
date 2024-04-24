using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;
using System.Drawing;
using System.Drawing.Imaging;
using api_diploma;
using System.Text;

namespace api_diploma.Data.Services
{
    public class PeopleService
    {
        AppDbContext _context;

        public PeopleService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPerson(PersonVM person, int userId)
        {
            byte[] imgBytes = FilesHelper.GetImageBytes(person.Signature);

            var _person = new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                DateOfBirth = person.DateOfBirth,
                Phone = person.Phone,
                Nationality = person.Nationality,
                Sex = person.Sex,
                MaritalStatus = person.MaritalStatus,
                Education = person.Education,
                PublicSpecialty = person.PublicSpecialty,
                Workplace = person.Workplace,
                TRSSC = person.TRSSC,
                RegistrationDate = person.RegistrationDate,
                DischargeDate = person.DischargeDate,
                DischargeReason = person.DischargeReason,
                Signature = imgBytes,
                NeedMMC = person.NeedMMC,
                LastMMC = person.LastMMC,
                Fine = person.Fine
            };

            _context.People.Add(_person);
            _context.SaveChanges();

            var newValue = new StringBuilder();
            newValue.AppendLine($"Id: {_person.Id}");
            newValue.AppendLine($"First Name: {_person.FirstName}");
            newValue.AppendLine($"Last Name: {_person.LastName}");
            newValue.AppendLine($"Middle Name: {_person.MiddleName}");
            newValue.AppendLine($"Date Of Birth: {_person.DateOfBirth}");
            newValue.AppendLine($"Phone: {_person.Phone}");
            newValue.AppendLine($"Nationality: {_person.Nationality}");
            newValue.AppendLine($"Sex: {_person.Sex}");
            newValue.AppendLine($"Marital Status: {_person.MaritalStatus}");
            newValue.AppendLine($"Education: {_person.Education}");
            newValue.AppendLine($"Public Specialty: {_person.PublicSpecialty}");
            newValue.AppendLine($"Workplace: {_person.Workplace}");
            newValue.AppendLine($"TRSSC: {_person.TRSSC}");
            newValue.AppendLine($"Registration Date: {_person.RegistrationDate}");
            newValue.AppendLine($"Discharge Date: {_person.DischargeDate}");
            newValue.AppendLine($"Discharge Reason: {_person.DischargeReason}");
            newValue.AppendLine($"Signature: {_person.Signature}");
            newValue.AppendLine($"Need MMC: {_person.NeedMMC}");
            newValue.AppendLine($"Last MMC: {_person.LastMMC}");
            newValue.AppendLine($"Fine: {_person.Fine}");

            HistoryHelper _helper = new HistoryHelper(_context);
            _helper.ChangeHistory("Add person", "null", newValue.ToString(), _person.Id, userId);

            _context.SaveChanges();
        }

        public List<Person> GetAllPeople() => _context.People.ToList();

        public Person GetPersonById(int id) => _context.People.FirstOrDefault(p => p.Id == id);

        private void UpdateField<T>(string fieldName, T oldValue, T newValue, StringBuilder oldValueBuilder, StringBuilder newValueBuilder, Action updateAction, ref bool changesDetected)
        {
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                oldValueBuilder.AppendLine($"{fieldName}: {oldValue}");
                newValueBuilder.AppendLine($"{fieldName}: {newValue}");
                updateAction.Invoke();
                changesDetected = true;
            }
        }

        public Person UpdatePersonById(int personId, PersonVM person, int userId)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == personId);

            if (_person == null)
            {
                return null;
            }

            var changesDetected = false;

            var oldValue = new StringBuilder();
            var newValue = new StringBuilder();

            UpdateField("First Name", _person.FirstName, person.FirstName, oldValue, newValue, () => _person.FirstName = person.FirstName, ref changesDetected);
            UpdateField("Last Name", _person.LastName, person.LastName, oldValue, newValue, () => _person.LastName = person.LastName, ref changesDetected);
            UpdateField("Middle Name", _person.MiddleName, person.MiddleName, oldValue, newValue, () => _person.MiddleName = person.MiddleName, ref changesDetected);
            UpdateField("Date Of Birth", _person.DateOfBirth, person.DateOfBirth, oldValue, newValue, () => _person.DateOfBirth = person.DateOfBirth, ref changesDetected);
            UpdateField("Phone", _person.Phone, person.Phone, oldValue, newValue, () => _person.Phone = person.Phone, ref changesDetected);
            UpdateField("Nationality", _person.Nationality, person.Nationality, oldValue, newValue, () => _person.Nationality = person.Nationality, ref changesDetected);
            UpdateField("Sex", _person.Sex, person.Sex, oldValue, newValue, () => _person.Sex = person.Sex, ref changesDetected);
            UpdateField("Marital Status", _person.MaritalStatus, person.MaritalStatus, oldValue, newValue, () => _person.MaritalStatus = person.MaritalStatus, ref changesDetected);
            UpdateField("Education", _person.Education, person.Education, oldValue, newValue, () => _person.Education = person.Education, ref changesDetected);
            UpdateField("Public Specialty", _person.PublicSpecialty, person.PublicSpecialty, oldValue, newValue, () => _person.PublicSpecialty = person.PublicSpecialty, ref changesDetected);
            UpdateField("Workplace", _person.Workplace, person.Workplace, oldValue, newValue, () => _person.Workplace = person.Workplace, ref changesDetected);
            UpdateField("TRSSC", _person.TRSSC, person.TRSSC, oldValue, newValue, () => _person.TRSSC = person.TRSSC, ref changesDetected);
            UpdateField("Registration Date", _person.RegistrationDate, person.RegistrationDate, oldValue, newValue, () => _person.RegistrationDate = person.RegistrationDate, ref changesDetected);
            UpdateField("Discharge Date", _person.DischargeDate, person.DischargeDate, oldValue, newValue, () => _person.DischargeDate = person.DischargeDate, ref changesDetected);
            UpdateField("Discharge Reason", _person.DischargeReason, person.DischargeReason, oldValue, newValue, () => _person.DischargeReason = person.DischargeReason, ref changesDetected);
            UpdateField("Need MMC", _person.NeedMMC, person.NeedMMC, oldValue, newValue, () => _person.NeedMMC = person.NeedMMC, ref changesDetected);
            UpdateField("Last MMC", _person.LastMMC, person.LastMMC, oldValue, newValue, () => _person.LastMMC = person.LastMMC, ref changesDetected);
            UpdateField("Fine", _person.Fine, person.Fine, oldValue, newValue, () => _person.Fine = person.Fine, ref changesDetected);

            if (changesDetected)
            {
                HistoryHelper _helper = new HistoryHelper(_context);
                _helper.ChangeHistory("Update person", oldValue.ToString(), newValue.ToString(), personId, userId);

                _context.SaveChanges();
            }

            return _person;
        }

        public void DeletePersonById(int personId)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == personId);
            if (_person != null )
            {
                var recordsAddr = _context.Address.Where(p => p.Id == personId).ToList();
                if (recordsAddr.Any())
                {
                    _context.Address.RemoveRange(recordsAddr);
                }

                var recordsAw = _context.Awards.Where(p => p.Id == personId).ToList();
                if (recordsAw.Any())
                {
                    _context.Awards.RemoveRange(recordsAw);
                }

                var recordsCP = _context.CombatParticipation.Where(p => p.Id == personId).ToList();
                if (recordsCP.Any())
                {
                    _context.CombatParticipation.RemoveRange(recordsCP);
                }

                var recordsF = _context.File.Where(p => p.Id == personId).ToList();
                if (recordsF.Any())
                {
                    _context.File.RemoveRange(recordsF);
                }

                var recordsCPH = _context.ChangePersonHistory.Where(p => p.Id == personId).ToList();
                if (recordsCPH.Any())
                {
                    _context.ChangePersonHistory.RemoveRange(recordsCPH);
                }

                var recordsI = _context.Injurie.Where(p => p.Id == personId).ToList();
                if (recordsI.Any())
                {
                    _context.Injurie.RemoveRange(recordsI);
                }

                var recordsMD = _context.MedicalData.Where(p => p.Id == personId).ToList();
                if ( recordsMD.Any())
                {
                    _context.MedicalData.RemoveRange(recordsMD);
                }

                var recordsP = _context.Parameter.Where(p => p.Id == personId).ToList();
                if (recordsP.Any())
                {
                    _context.Parameter.RemoveRange(recordsP);
                }

                var recordsSH = _context.ServiceHistory.Where(p => p.Id == personId).ToList();
                if (recordsSH.Any())
                {
                    _context.ServiceHistory.RemoveRange(recordsSH);
                }

                _context.People.Remove(_person);
                _context.SaveChanges();
            }
        }
    }
}
