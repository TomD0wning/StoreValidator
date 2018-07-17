using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StoreValidator.Models;
using StoreValidator.Services;
using StoreValidator.ViewModels;

namespace StoreValidator.Controllers
{
    public class HomeController : Controller
    {
        private IStoreData _storeData;

        public HomeController(IStoreData storeData)
        {
            _storeData = storeData;

        }

        public IActionResult Index()
        {

            //Instantiate a new instance of store from the HomeView model
            var model = new HomeIndexViewModel();
                            

            model.Stores = _storeData.GetAll();

            return View(model);
        }

        public IActionResult Details(int id){
            var model = _storeData.Get(id);
            if (model == null){
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(StoreEditModel model){
            if(ModelState.IsValid){
                var newStore = new Store();

                newStore.Name = model.Name;
                newStore.Address = model.Address;
                newStore.Desc = model.Desc;
                newStore.PostCode = model.PostCode;
                newStore.StoreSize = model.StoreSize;
                newStore.StoreType = model.StoreType;
                newStore.OpenDate = model.OpenDate;

                newStore = _storeData.Add(newStore);

                return RedirectToAction(nameof(Details), new { id = newStore.Id });
            }else{
                return View();
            }

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
