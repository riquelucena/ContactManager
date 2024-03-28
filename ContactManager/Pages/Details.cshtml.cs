using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Contact = await _getByIdContactBusiness.GetByIdAsync(id);
                if (Contact == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching contact with ID: {id}.");
                return StatusCode(500, "Internal Server Error");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _updateContactBusiness.UpdateAsync(Contact);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating contact with ID: {Contact.ID}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                await _deleteContactBusiness.DeleteAsync(id);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting contact with ID: {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
