using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManager.Pages
{
    public class RegistryModel : PageModel
    {
        private readonly ILogger<RegistryModel> _logger;
        private readonly IAddContactsBusiness _addContactsBusiness;

        public ContactModel Contact { get; set; } = new ContactModel();

        public RegistryModel(
            ILogger<RegistryModel> logger,
            IAddContactsBusiness addContactsBusiness
            )
        {
            _logger = logger;
            _addContactsBusiness = addContactsBusiness;
        }

        public async Task<IActionResult> ContactRegistry(ContactModel contact)
        {
            try
            {
                await _addContactsBusiness.AddAsync(contact);
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the contact.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}