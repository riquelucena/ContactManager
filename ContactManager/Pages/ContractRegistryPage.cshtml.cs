using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactManager.Model;
using ContactManager.Interfaces;

namespace ContactManager.Pages
{
    public class ContractRegistryPageModel : PageModel
    {
        private readonly IAddContactsBusiness _addContactsBusiness;

        [BindProperty]
        public ContactModel NewContact { get; set; }

        public ContractRegistryPageModel(IAddContactsBusiness addContactsBusiness)
        {
            _addContactsBusiness = addContactsBusiness;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _addContactsBusiness.Add(NewContact);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}

