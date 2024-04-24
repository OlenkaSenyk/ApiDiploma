namespace api_diploma.Data.ViewModels
{
    public class ServiceHistoryVM
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string MilitaryRank { get; set; }
        public string MilitaryCategory { get; set; }
        public string MilitaryBranch { get; set; }
        public string MilitaryUnit { get; set; }
        public int PersonID { get; set; }
    }
}
