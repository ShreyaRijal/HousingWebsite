using HousingWebsite.Mappers;
using HousingWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            List<Property> Properties = _db.Property.Where(x => x.PropertiesForRent != null && x.PropertiesForRent.Count > 0).ToList();

            RentalPropetiesViewModel propertiesViewModel = new RentalPropetiesViewModel
            {
                RentalProperties = new List<RentalPropertyViewModel>()
            };

            foreach (Property property in Properties)
            {
                RentalPropertyViewModel propertyViewModel = RentalPropertyMapper.MapPropertyToRentalPropertyVM(property);
                propertiesViewModel.RentalProperties.Add(propertyViewModel);
            }

            return View(propertiesViewModel);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            //Implement elastic search or some other search engine to do this
            return Index();
        }

        [HttpGet]
        public IActionResult SpecificProperty(int rentalId)
        {
            PropertiesForRent propertyForRent = _db.PropertiesForRent.Where(p => p.RentalId == rentalId).FirstOrDefault();
            Property property = _db.Property.Where(p => p.PropertiesForRent.First().RentalId == rentalId).FirstOrDefault();

            RentalPropertyViewModel propertyViewModel = RentalPropertyMapper.MapPropertyToRentalPropertyVM(property);

            return View(propertyViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
