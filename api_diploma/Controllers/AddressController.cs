using api_diploma.Data.Services;
using api_diploma.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_diploma.Controllers
{
    [Route("addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public AddressesService _addressesService;

        public AddressController(AddressesService addressesService)
        {
            _addressesService = addressesService;
        }
        /*
        [HttpGet]
        public IActionResult GetAllAddresses()
        {
            return Ok(_addressesService.GetAllAddresses());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            return Ok(_addressesService.GetAddressById(id));
        }

        [HttpGet("people/{id}")]
        public IActionResult GetAddressByPersonId(int id)
        {
            return Ok(_addressesService.GetAddressByPersonId(id));
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressVM address)
        {
            _addressesService.AddAddress(address);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddressById(int id, [FromBody] AddressVM address)
        {
            return Ok(_addressesService.UpdateAddressById(id, address));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddressById(int id)
        {
            _addressesService.DeleteAddressById(id);
            return Ok();
        }
        */
    }
}
