using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreValidator.Models;

namespace StoreValidator.Services
{
    public class InMemStore : IStoreData
    {
        private List<Store> _store;

        public InMemStore()
        {
            _store = new List<Store>
            {
                new Store {Id=1,Name="Rugby", Desc="Store in Rugby", Address="1 street", PostCode="CV11 4AA", OpenDate="17060801", StoreSize=10000},
                new Store {Id=2,Name="London", Desc="Store in London", Address="Buckingham Palace", PostCode="CV11 4AA", OpenDate="18000101", StoreSize=100000},
                new Store {Id=3,Name="Aberystwyth", Desc="Welsh store", Address="in a valley", PostCode="WA2 1ES", OpenDate="20201214", StoreSize=5},
                new Store {Id=4,Name="Mirkwood", Desc="Store in Middle earth", Address="The forest", PostCode="ME0 1AH", OpenDate="20110505", StoreSize=4894}

            };
        }

        public Store Add(Store store)
        {
            throw new NotImplementedException();
        }

        public Store Get(int id)
        {
            return _store.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Store> GetAll()
        {
            return _store.OrderBy(s => s.Name);
        }

        public Store Remove(Store store)
        {
            int StoreId = store.Id;
             _store.RemoveAt(StoreId);
            //TODO - needs to changed to return a success or failure
            return store;
        }

        public Store Update(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
