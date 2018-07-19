
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreValidator.Models;
using StoreValidator.Services;

namespace StoreValidator.Pages.Stores
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Store Store { get; set; }

        private IStoreData _storeData;

        public CreateModel(IStoreData storeData)
        {
            _storeData = storeData;
        }
        public IActionResult OnGet()
        {
            //Store = _storeData.Get(id);
            //if (Store == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _storeData.Add(Store);
                return RedirectToAction("Details", "Home", new { Id = Store.Id });
            }
            return Page();

        }
    }
}