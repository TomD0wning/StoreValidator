using System;
using System.Diagnostics;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using StoreValidator.Models;
using StoreValidator.Services;
using StoreValidator.ViewModels;
using Microsoft.Extensions.Logging;

namespace StoreValidator.Controllers
{
    public class HomeController : Controller
    {
        private IStoreData _storeData;
        private ILogger<HomeController> _logger;

        public HomeController(IStoreData storeData, ILogger<HomeController> logger)
        {
            _storeData = storeData;
            _logger = logger;
        }

        public IActionResult Index()
        {

            //Instantiate a new instance of store from the HomeView model
            var model = new HomeIndexViewModel
            {
                Stores = _storeData.GetAll()
            };

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _storeData.Get(id);
            if (model == null)
            {
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
        public IActionResult Create(StoreEditModel model)
        {
            var newStore = new Store
            {
                Name = model.Name,
                Address = model.Address,
                Desc = model.Desc,
                PostCode = model.PostCode,
                StoreSize = model.StoreSize,
                StoreType = model.StoreType,
                OpenDate = model.OpenDate,
                Concessions = model.Concessions,
                Department = model.Departments
            };

            var validator = new StoreDataValidator();
            var results = validator.Validate(newStore);
            results.AddToModelState(ModelState, null);

            if (ModelState.IsValid)
            {

                newStore = _storeData.Add(newStore);

                return RedirectToAction(nameof(Details), new { id = newStore.Id });
            }
            else
            {
                foreach (var Modelvalue in ModelState.Values)
                    {
                        foreach(var e in Modelvalue.Errors)
                        _logger.LogDebug(e.ErrorMessage);
                    }
                return View();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
