namespace api_diploma.Data.ViewModels
{
    public class CombatParticipationVM
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Location { get; set; }
        public string OperationType { get; set; }
        public int PersonId { get; set; }
    }
}
