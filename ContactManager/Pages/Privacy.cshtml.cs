using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IAddContactsBusiness _addContactsBusiness;

        public ContactModel Contact { get; set; } = new ContactModel();

        public PrivacyModel(
            ILogger<PrivacyModel> logger,
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