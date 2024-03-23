using ContactManager.Business;
using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ContactManager.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly IGetByIdContactBusiness _getByIdContactBusiness;
        private readonly IUpdateContactBusiness _updateContactBusiness;
        private readonly IDeleteContactBusiness _deleteContactBusiness;

        public ContactModel Contact { get; set; }

        public DetailsModel(
            ILogger<DetailsModel> logger,
            IGetByIdContactBusiness getByIdContactBusiness,
            IUpdateContactBusiness updateContactBusiness,
            IDeleteContactBusiness deleteContactBusiness)
        {
            _logger = logger;
            _getByIdContactBusiness = getByIdContactBusiness;
            _updateContactBusiness = updateContactBusiness;
            _deleteContactBusiness = deleteContactBusiness;
        }

        public async Task<IActionResult> GetContactById(int id)
        {
            try
            {
                var contact = await _getByIdContactBusiness.GetByIdAsync(id);
                if (contact == null)
                    return NotFound();

                return StatusCode(200, contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching contact with ID: {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        public async Task<IActionResult> UpdateContact(int id, ContactModel contact)
        {
            try
            {
                contact.ID = id;
                await _updateContactBusiness.UpdateAsync(contact);
                return StatusCode(200, contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating contact with ID: {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _deleteContactBusiness.DeleteAsync(id);
                return StatusCode(200, "Deleted contact.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting contact with ID: {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

