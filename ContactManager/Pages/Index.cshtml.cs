using ContactManager.Business;
using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGetAllContactsBusiness _getAllContactsBusiness;

        public IndexModel(
            ILogger<IndexModel> logger,
            IGetAllContactsBusiness getAllContactsBusiness)
        {
            _logger = logger;
            _getAllContactsBusiness = getAllContactsBusiness;
        }

        public IList<ContactModel> Contacts { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Contacts = await _getAllContactsBusiness.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all contacts.");
            }
        }        
    }
}