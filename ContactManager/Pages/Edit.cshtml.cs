using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ContactManager.Pages
{
    public class EditModel : PageModel
    {
        private readonly IGetByIdContactBusiness _getByIdContactBusiness;
        private readonly IUpdateContactBusiness _updateContactBusiness;

        [BindProperty]
        public ContactModel Contact { get; set; }

        public EditModel(IGetByIdContactBusiness getByIdContactBusiness, IUpdateContactBusiness updateContactBusiness)
        {
            _getByIdContactBusiness = getByIdContactBusiness;
            _updateContactBusiness = updateContactBusiness;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _getByIdContactBusiness.GetByIdAsync(id.Value);

            if (Contact == null)
            {
                return NotFound();
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _updateContactBusiness.UpdateAsync(Contact);
                return RedirectToPage("./Details", new { id = Contact.ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while updating contact with ID {Contact.ID}: {ex.Message}");
                return Page();
            }
        }
    }
}
