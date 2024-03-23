using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGetAllContactsBusiness _getAllContactsBusiness;

        public IndexModel(IGetAllContactsBusiness getAllContactsBusiness)
        {
            _getAllContactsBusiness = getAllContactsBusiness;
        }

        public IList<ContactModel> Contacts { get; set; }

        public void OnGet()
        {
            Contacts = _getAllContactsBusiness.GetAll();
        }
    }
}
