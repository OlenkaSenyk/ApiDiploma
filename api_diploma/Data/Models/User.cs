namespace api_diploma.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }

        public List<ChangePersonHistory> ChangePersonHistories { get; set; } = new List<ChangePersonHistory>();
        public List<Document> Documents { get; set; } = new List<Document>();
        public List<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();
    }
}
