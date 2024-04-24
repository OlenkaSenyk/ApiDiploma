using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;

namespace api_diploma.Data.Services
{
    public class AddressesService
    {
        AppDbContext _context;
        public AddressesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAddress(AddressVM address)
        {
            var _person = _context.People.FirstOrDefault(p => p.Id == address.PersonId);

            if (_person != null)
            {
                var _address = new Address()
                {
                    Country = address.Country,
                    City = address.City,
                    Region = address.Region,
                    Street = address.Street,
                    House = address.House,
                    Entrance = address.Entrance,
                    Apartment = address.Apartment,
                    ResidenceOrRegistration = address.ResidenceOrRegistration,
                    Person = _person
                };

                _context.Address.Add(_address);
                _context.SaveChanges();
            }
        }

        public List<Address> GetAllAddresses() => _context.Address.ToList();

        public Address GetAddressById(int id) => _context.Address.FirstOrDefault(p => p.Id == id);

        public List<Address> GetAddressByPersonId(int id) => _context.Address.Where(p => p.PersonId == id).ToList();

        public Address UpdateAddressById(int id, AddressVM address)
        {
            var _address = _context.Address.FirstOrDefault(p => p.Id == id);

            if (_address != null)
            {
                _address.Country = address.Country;
                _address.City = address.City;
                _address.Region = address.Region;
                _address.Street = address.Street;
                _address.House = address.House;
                _address.Entrance = address.Entrance;
                _address.Apartment = address.Apartment;
                _address.ResidenceOrRegistration = address.ResidenceOrRegistration;

                _context.SaveChanges();
            }

            return _address;
        }

        public void DeleteAddressById(int id)
        {
            var _address = _context.Address.FirstOrDefault(p => p.Id == id);
            if (_address != null)
            {
                _context.Address.Remove(_address);
                _context.SaveChanges();
            }
        }
    }
}
