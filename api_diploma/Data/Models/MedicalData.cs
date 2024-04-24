namespace api_diploma.Data.Models
{
    public class MedicalData
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public string BloodRh { get; set; }
        public bool Eligibility { get; set; }
        public string Features { get; set; }
        public string Notes { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
