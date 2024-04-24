using api_diploma.Data.Models;

namespace api_diploma.Data.ViewModels
{
    public class AddressVM
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int? Entrance { get; set; }
        public int? Apartment { get; set; }
        public string ResidenceOrRegistration { get; set; }
        public int PersonId { get; set; }
    }
}
