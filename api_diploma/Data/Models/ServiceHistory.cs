namespace api_diploma.Data.Models
{
    public class ServiceHistory
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string MilitaryRank { get; set; }
        public string MilitaryCategory { get; set; }
        public string MilitaryBranch { get; set; }
        public string MilitaryUnit { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
