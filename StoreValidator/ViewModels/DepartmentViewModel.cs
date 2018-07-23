using System;
using System.Collections.Generic;
using StoreValidator.Models;

namespace StoreValidator.ViewModels
{
    public class DepartmentViewModel
    {
        
        public IEnumerable<StoreDepartment> Departments { get; set; }
        
    }
}
