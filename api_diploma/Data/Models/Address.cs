namespace api_diploma.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int? Entrance { get; set; }
        public int? Apartment { get; set; }
        public string ResidenceOrRegistration { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
