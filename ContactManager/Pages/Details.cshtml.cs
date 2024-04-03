using System;
using System.Threading.Tasks;
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
        private readonly IDeleteContactBusiness _deleteContactBusiness;

        public ContactModel Contact { get; private set; }

        public DetailsModel(ILogger<DetailsModel> logger,
            IGetByIdContactBusiness getByIdContactBusiness,
            IDeleteContactBusiness deleteContactBusiness)
        {
            _logger = logger;
            _getByIdContactBusiness = getByIdContactBusiness;
            _deleteContactBusiness = deleteContactBusiness;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            try
            {
                Contact = await _getByIdContactBusiness.GetByIdAsync(id.Value);
                if (Contact == null)
                {
                    ModelState.AddModelError(string.Empty, $"Contact with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while fetching contact with ID {id}: {ex.Message}");
            }

            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                await _deleteContactBusiness.DeleteAsync(id);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while deleting contact with ID {id}: {ex.Message}");
                return Page();
            }
        }
    }
}


    
    