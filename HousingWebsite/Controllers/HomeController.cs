using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HousingWebsite.Models;

namespace HousingWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly RentalWebsiteContext _db;

        public HomeController(RentalWebsiteContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<PropertiesForRent> PropertiesForRent = _db.PropertiesForRent.ToList();
            List<Property> Properties = _db.Property.ToList();

            return View(PropertiesForRent);
        }

        [HttpGet]
        public IActionResult SpecificProperty(int RentalId)
        {
            PropertiesForRent pr = _db.PropertiesForRent.Where(p => p.Property.First().PropertyId == RentalId).FirstOrDefault();
            List<Property> Properties = _db.Property.ToList();

            return View(pr);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
