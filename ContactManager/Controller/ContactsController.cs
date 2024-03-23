using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IAddContactsBusiness _addContactsBusiness;

        public ContactsController(
            ILogger<ContactsController> logger, IAddContactsBusiness addContactsBusiness)
        {
            _logger = logger;
            _addContactsBusiness = addContactsBusiness;
        }

        [HttpPost]
        public IActionResult ContactRegistry([FromBody] ContactModel contact)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
