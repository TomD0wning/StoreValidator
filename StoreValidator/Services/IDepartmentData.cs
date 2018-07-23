using System;
using System.Collections.Generic;
using StoreValidator.Models;

namespace StoreValidator.Services
{
    public interface IDepartmentData
    {

        StoreDepartment Get(int id);
        IEnumerable<StoreDepartment> GetAll();
        StoreDepartment Add(StoreDepartment storeDept);
        StoreDepartment Remove(StoreDepartment storeDept);

    }
}