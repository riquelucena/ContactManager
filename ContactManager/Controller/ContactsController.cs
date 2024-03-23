using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IAddContactsBusiness _addContactsBusiness;
        private readonly IGetAllContactsBusiness _getAllContactsBusiness;
        private readonly IGetByIdContactBusiness _getByIdContactBusiness;
        private readonly IUpdateContactBusiness _updateContactBusiness;
        private readonly IDeleteContactBusiness _deleteContactBusiness;

        public ContactsController(
            ILogger<ContactsController> logger,
            IAddContactsBusiness addContactsBusiness,
            IGetAllContactsBusiness getAllContactsBusiness,
            IGetByIdContactBusiness getByIdContactBusiness,
            IUpdateContactBusiness updateContactBusiness,
            IDeleteContactBusiness deleteContactBusiness)
        {
            _logger = logger;
            _addContactsBusiness = addContactsBusiness;
            _getAllContactsBusiness = getAllContactsBusiness;
            _getByIdContactBusiness = getByIdContactBusiness;
            _updateContactBusiness = updateContactBusiness;
            _deleteContactBusiness = deleteContactBusiness;
        }

        [HttpPost]
        public IActionResult ContactRegistry(ContactModel contact)
        {
            try
            {
                _addContactsBusiness.Add(contact);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the contact.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            try
            {
                IList<ContactModel> contacts = _getAllContactsBusiness.GetAll();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all contacts.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            try
            {
                ContactModel contact = _getByIdContactBusiness.GetById(id);
                if (contact == null)
                    return NotFound();

                return Ok(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching contact with ID: {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactModel contact)
        {
            try
            {
                contact.ID = id;
                _updateContactBusiness.Update(contact);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating contact with ID: {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                _deleteContactBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting contact with ID: {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
