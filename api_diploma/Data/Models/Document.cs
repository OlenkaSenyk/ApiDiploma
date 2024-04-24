namespace api_diploma.Data.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public byte[] ScanCopy { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
