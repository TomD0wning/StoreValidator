using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreValidator.Models;
using StoreValidator.Services;

namespace StoreValidator.Pages.Stores
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Store Store { get; set; }

        private IStoreData _storeData;

        public EditModel(IStoreData storeData)
        {
            _storeData = storeData;
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
            if (ModelState.IsValid)
            {
                _storeData.Update(Store);
                return RedirectToAction("Details", "Home", new { Id = Store.Id });
            }
            return Page();
        }
    }
}
