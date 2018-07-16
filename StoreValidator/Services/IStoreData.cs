using StoreValidator.Models;
using System.Collections.Generic;

namespace StoreValidator.Services
{
    public interface IStoreData
    {

        IEnumerable<Store> GetAll();
        Store Get(int id);
        Store Add(Store store);
        Store Update(Store store);
        Store Remove(Store store);


    }
}
