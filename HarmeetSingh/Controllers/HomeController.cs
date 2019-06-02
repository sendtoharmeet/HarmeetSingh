using BusinessApi;
using HarmeetSingh.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Contract = DataContract;

namespace HarmeetSingh.Controllers
{
    public class HomeController : Controller
    {
        IDataProcessor _dataProcessor;
        public HomeController(IDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                var sharedPerson = new Contract.Person() { Amount = person.Amount, Id = person.ID, Name = person.Name };
                var processedModel = _dataProcessor.ProcessPerson(sharedPerson);
                return View("Detail", processedModel);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Detail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Error { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
