using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StoreValidator.Models;
using StoreValidator.Services;

namespace StoreValidator.Pages.Stores
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Store Store { get; set; }

        private IStoreData _storeData;
        private ILogger _logger;

        public EditModel(IStoreData storeData, ILogger logger)
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

            var validator = new StoreDataValidator();
            var results = validator.Validate(Store);
            results.AddToModelState(ModelState, null);

            
            if (ModelState.IsValid)
            {
                
                _storeData.Update(Store);
                _logger.LogInformation("{0} updated", Store.Name);
                return RedirectToAction("Details", "Home", new { Id = Store.Id });
            }
            else
            {
                foreach (var Modelvalue in ModelState.Values)
                {
                    foreach (var e in Modelvalue.Errors)
                        _logger.LogDebug(e.ErrorMessage);
                }

                return Page();
            }
            
            
        }
    }
}
