using System.Reflection.Metadata;

namespace api_diploma.Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }
        public string Education { get; set; }
        public string? PublicSpecialty { get; set; }
        public string? Workplace { get; set; }
        public string TRSSC { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public DateOnly? DischargeDate { get; set; }
        public string? DischargeReason { get; set; }
        public byte[] Signature { get; set; }
        public bool NeedMMC { get; set; }
        public DateOnly? LastMMC { get; set; }
        public double? Fine { get; set;}

        public List<Award> Awards { get; set; } = new();
        public List<Address> Addresses { get; set; }
        public List<CombatParticipation> CombatParticipations { get; set; }
        public List<Injurie> Injuries { get; set; }
        public List <ServiceHistory> ServiceHistories { get; set; }
        public File Files { get; set; }
        public Parameter Parameters { get; set; }
        public MedicalData MedicalData { get; set; }
        public List<ChangePersonHistory> ChangePersonHistories { get; set; } = new List<ChangePersonHistory>();
    }
}
