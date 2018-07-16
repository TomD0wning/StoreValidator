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

        public IActionResult Index()
        {

            //Instantiate a new instance of store from the HomeView model
            var model = new HomeIndexViewModel();

            model.Store = _storeData.GetAll();

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
