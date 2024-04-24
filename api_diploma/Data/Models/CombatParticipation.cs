namespace api_diploma.Data.Models
{
    public class CombatParticipation
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Location { get; set; }
        public string OperationType { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
