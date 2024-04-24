namespace api_diploma.Data.Models
{
    public class ChangePersonHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
