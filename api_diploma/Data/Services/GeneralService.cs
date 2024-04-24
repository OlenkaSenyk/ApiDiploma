namespace api_diploma.Data.Services
{
    public class GeneralService
    {
        AppDbContext _context;
        public GeneralService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<object> GetFullInfo()
        {
            var query = from person in _context.People
                        select new
                        {
                            Person = person,
                            Address = _context.Address.Where(a => a.PersonId == person.Id).ToList(),
                            Awards = _context.Awards.Where(a => a.PersonId == person.Id).ToList(),
                            CombatParticipation = _context.CombatParticipation.Where(a => a.PersonId == person.Id).ToList(),
                            File = _context.File.SingleOrDefault(a => a.PersonId == person.Id),
                            Injurie = _context.Injurie.Where(a => a.PersonId == person.Id).ToList(),
                            MedicalData = _context.MedicalData.SingleOrDefault(a => a.PersonId == person.Id),
                            Parameter = _context.Parameter.SingleOrDefault(a => a.PersonId == person.Id),
                            ServiceHistory = _context.ServiceHistory.Where(a => a.PersonId == person.Id).ToList()
                        };

            return query.ToList().Select(item => new
            {
                item.Person.Id,
                item.Person.FirstName,
                item.Person.LastName,
                item.Person.MiddleName,
                item.Person.DateOfBirth,
                item.Person.Sex,
                item.Person.Nationality,
                item.Person.Phone,
                item.Person.MaritalStatus,
                item.Person.Education,
                item.Person.Workplace,
                item.Person.PublicSpecialty,
                item.Person.RegistrationDate,
                item.Person.DischargeDate,
                item.Person.DischargeReason,
                item.Person.TRSSC,
                item.Person.NeedMMC,
                item.Person.LastMMC,
                item.Person.Fine,
                item.Person.Signature,
                Addresses = item.Address.Select(a => new
                {
                    a.Country,
                    a.City,
                    a.Region,
                    a.Street,
                    a.House,
                    a.Entrance,
                    a.Apartment,
                    a.ResidenceOrRegistration
                }),
                Awards = item.Awards.Select(a => new
                {
                    a.Name,
                    a.Date,
                    a.Reason
                }),
                CombatParticipation = item.CombatParticipation.Select(a => new
                {
                    a.StartDate,
                    a.EndDate,
                    a.Location,
                    a.OperationType
                }),
                File = item.File != null ? new
                {
                    item.File.Passport,
                    item.File.IndividualTaxNumber,
                    item.File.MedicalCertificate,
                    item.File.Photo,
                    item.File.ResidencePermit
                } : null,
                Injurie = item.Injurie.Select(a => new
                {
                    a.Date,
                    a.Location,
                    a.Type,
                    a.MedicalAssistance,
                    a.Notes
                }),
                MedicalData = item.MedicalData != null ? new
                {
                    item.MedicalData.BloodType,
                    item.MedicalData.BloodRh,
                    item.MedicalData.Eligibility,
                    item.MedicalData.Features,
                    item.MedicalData.Notes
                } : null,
                Parameter = item.Parameter != null ? new
                {
                    item.Parameter.Height,
                    item.Parameter.Width,
                    item.Parameter.ShoeSize,
                    item.Parameter.ClothingSize,
                    item.Parameter.HeadCircumference,
                    item.Parameter.GasMaskSize
                } : null,
                ServiceHistory = item.ServiceHistory.Select(a => new
                {
                    a.StartDate,
                    a.EndDate,
                    a.MilitaryRank,
                    a.MilitaryCategory,
                    a.MilitaryBranch,
                    a.MilitaryUnit
                })
            }).ToList();
        }
    }
}
