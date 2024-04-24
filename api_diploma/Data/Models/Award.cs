namespace api_diploma.Data.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public string Reason { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
