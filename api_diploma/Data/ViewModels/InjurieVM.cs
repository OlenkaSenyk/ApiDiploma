namespace api_diploma.Data.ViewModels
{
    public class InjurieVM
    {
        public DateOnly Date { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string MedicalAssistance { get; set; }
        public string? Notes { get; set; }
        public int PersonId { get; set; }
    }
}
