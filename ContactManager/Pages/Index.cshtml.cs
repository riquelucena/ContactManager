using ContactManager.Business;
using ContactManager.Interfaces;
using ContactManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
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

        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var contacts = await _getAllContactsBusiness.GetAllAsync();
                return new OkObjectResult(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all contacts.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        public IList<ContactModel> Contacts { get; set; }
    }
}