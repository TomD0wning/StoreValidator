using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StoreValidator.Models;
using StoreValidator.Services;

namespace StoreValidator.Pages.Stores
{
    public class RemoveModel : PageModel
    {
        [BindProperty]
        public Store Store { get; set; }

        private IStoreData _storeData;
        private ILogger _logger;

        public RemoveModel(IStoreData storeData, ILogger<RemoveModel> logger)
        {
            _storeData = storeData;
            _logger = logger;
        }
        public IActionResult OnGet(int id)
        {
            Store = _storeData.Get(id);
            if (Store == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
                _logger.LogDebug("Delete operation triggered");
                _storeData.Remove(Store);
                _logger.LogDebug("{0} : {1} Removed", Store.Id,Store.Name);
                return RedirectToAction("Index", "Home");
        }
    }
}