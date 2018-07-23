using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StoreValidator.Services;
using StoreValidator.Models;
using StoreValidator.ViewModels;
using System.Diagnostics.Contracts;

namespace StoreValidator.Pages.Stores
{
    public class EditDepartmentModel : PageModel
    {

        [BindProperty]
        public StoreDepartment StoreDept { get; set; }

        private IDepartmentData _deptData;
        private ILogger  _logger;


        public EditDepartmentModel(IDepartmentData deptData, ILogger<EditDepartmentModel> logger)
        {
            _deptData = deptData;
            _logger = logger;
        }



        public IActionResult OnGet()
        {
            Contract.Ensures(Contract.Result<IActionResult>() != null);
            var model = new DepartmentViewModel();
            model.Departments = _deptData.GetAll();

            return Page();
        }


        public IActionResult OnPost(){
            return Page();
        }
    }
}