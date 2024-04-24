namespace api_diploma.Data.ViewModels
{
    public class AwardVM
    {
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public string Reason { get; set; }
        public int PersonId { get; set; }
    }
}
