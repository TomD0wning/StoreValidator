using System.Collections.Generic;
using StoreValidator.Models;
using StoreValidator.Services;
using StoreValidator.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreValidator
{
    internal class SqlDepartmentData : IDepartmentData
    {
        private StoreValidatorDbContext _context;

        public SqlDepartmentData(StoreValidatorDbContext context)
        {
            _context = context;
        }

        public StoreDepartment Add(StoreDepartment storeDept)
        {
            _context.StoreDepts.Add(storeDept);
            _context.SaveChanges();

            return storeDept;

        }

        public StoreDepartment Get(int id)
        {
            return _context.StoreDepts.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<StoreDepartment> GetAll()
        {
            return _context.StoreDepts.OrderBy(s => s.Name);
        }

        public StoreDepartment Remove(StoreDepartment storeDept)
        {
            _context.StoreDepts.Remove(storeDept);
            _context.SaveChanges();
            return storeDept;
        }

        //public StoreDepartment Update(StoreDepartment store)
        //{
        //    _context.Attach(store).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    return store;
        //}
    }
}