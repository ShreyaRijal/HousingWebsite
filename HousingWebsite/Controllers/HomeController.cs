using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HousingWebsite.Models;
using System.IO;

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

                RentalPropertyViewModel propertyViewModel = new RentalPropertyViewModel()
                {
                    PropertyId = property.PropertyId,
                    AddressLine1 = property.AddressLine1,
                    City = property.City,
                    PostCode = property.PostCode,
                    Country = property.Country,
                    PropertyType = property.PropertyType,
                    BuildDate = property.BuildDate,
                    NoOfBedrooms = property.NoOfBedrooms,
                    Garden = property.Garden,
                    Parking = property.Parking,
                    Epcrating = property.Epcrating,
                    RentalId = property.PropertiesForRent.First().RentalId,
                    PricePcm = property.PropertiesForRent.First().PricePcm,
                    PetsAllowed = property.PropertiesForRent.First().PetsAllowed,
                    PropertyAvailableFrom = property.PropertiesForRent.First().PropertyAvailableFrom,
                    PropertyPhotos = property.PhotoRef                    
                };
                propertiesViewModel.RentalProperties.Add(propertyViewModel);
            }

            return View(propertiesViewModel);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            string searchInput = search;

            //Implement elastic search or some other search engine to do this

            return Index();
        }

        [HttpGet]
        public IActionResult SpecificProperty(int rentalId)
        {
            PropertiesForRent propertyForRent = _db.PropertiesForRent.Where(p => p.RentalId == rentalId).FirstOrDefault();
            Property property = _db.Property.Where(p => p.PropertiesForRent.First().RentalId == rentalId).FirstOrDefault();

            RentalPropertyViewModel propertyViewModel = new RentalPropertyViewModel()
            {
                PropertyId = property.PropertyId,
                AddressLine1 = property.AddressLine1,
                City = property.City,
                PostCode = property.PostCode,
                Country = property.Country,
                PropertyType = property.PropertyType,
                BuildDate = property.BuildDate,
                NoOfBedrooms = property.NoOfBedrooms,
                Garden = property.Garden,
                Parking = property.Parking,
                Epcrating = property.Epcrating,
                RentalId = property.PropertiesForRent.First().RentalId,
                PricePcm = property.PropertiesForRent.First().PricePcm,
                PetsAllowed = property.PropertiesForRent.First().PetsAllowed,
                PropertyAvailableFrom = property.PropertiesForRent.First().PropertyAvailableFrom,
                PropertyPhotos = property.PhotoRef
            };

            return View(propertyViewModel);
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
