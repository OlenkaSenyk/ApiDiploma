namespace api_diploma.Data.Models
{
    public class Injurie
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string MedicalAssistance { get; set; }
        public string? Notes { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
