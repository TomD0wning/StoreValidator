using System.Collections.Generic;
using StoreValidator.Models;
using StoreValidator.Services;
using StoreValidator.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreValidator
{
    internal class SqlStoreData : IStoreData
    {
        private StoreValidatorDbContext _context;

        public SqlStoreData(StoreValidatorDbContext context)
        {
            _context = context;
        }

        public Store Add(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();

            return store;

        }

        public Store Get(int id)
        {
            return _context.Stores.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Store> GetAll()
        {
             return _context.Stores.OrderBy(s => s.Name);
        }

        public Store Remove(Store store)
        {
            _context.Stores.Remove(store);
          
            _context.SaveChanges();
            return store;
        }

        public Store Update(Store store)
        {
            _context.Attach(store).State = EntityState.Modified;
            _context.SaveChanges();
            return store;
        }
    }
}