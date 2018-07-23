using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreValidator.Models
{
    public class StoreDepartment
    { 

        public int DepartmentId { get; set; }

        public Department Name { get; set; }

        public string DepDescription { get; set; }

        public long DepSize { get; set; }

        public int Id { get; set; }
    }
}
