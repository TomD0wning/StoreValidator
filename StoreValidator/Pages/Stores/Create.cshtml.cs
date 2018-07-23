
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreValidator.Models;
using StoreValidator.Services;
using Microsoft.Extensions.Logging;

namespace StoreValidator.Pages.Stores
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Store Store { get; set; }

        private IStoreData _storeData;
        private ILogger _logger;
        public CreateModel(IStoreData storeData, ILogger logger)
        {
            _storeData = storeData;
            _logger = logger;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _logger.LogDebug("Adding new store {0}, {1}", Store.Id, Store.Name);
                _storeData.Add(Store);
                return RedirectToAction("Details", "Home", new { Id = Store.Id });
            }

            _logger.LogDebug("Failed Validation...");
            return Page();

        }
    }
}