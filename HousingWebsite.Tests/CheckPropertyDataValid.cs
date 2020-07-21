using HousingWebsite.Mappers;
using HousingWebsite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace HousingWebsite.Tests
{
    [TestClass]
    public class CheckPropertyDataValid
    {
        [TestMethod]
        public void CheckPropertyIdValid()
        {
            var property = GetDummyPropertyWithValidRentalData();

            Assert.IsTrue(property.PropertyId > 0);
        }

        [TestMethod]
        public void CheckAddressLine1Valid()
        {
            var property = GetDummyPropertyWithValidRentalData();

            Assert.IsTrue(property.AddressLine1 != "");
        }

        [TestMethod]
        public void CheckCityValid()
        {
            var property = GetDummyPropertyWithValidRentalData();

            Assert.IsTrue(property.City != "");
        }

        private Property GetDummyPropertyWithValidRentalData()
        {
            var property = new Property()
            {
                PropertyId = 0,
                AddressLine1 = "34 St James Rd",
                City = "London",
                PostCode = "LA11 62F",
                Country = "UK",
                PropertyType = "House",
                BuildDate = DateTime.MinValue,
                NoOfBedrooms = 3,
                Garden = true,
                Parking = true,
                Epcrating = "B",
                PhotoRef = "25d3d4de-3e8d-4d87-968c-1e8d5a6b303e"
            };

            var propertiesForRent = new PropertiesForRent()
            {
                RentalId = 1,
                PropertyId = 1,
                PricePcm = 1200,
                PetsAllowed = true,
                PropertyAvailableFrom = DateTime.MinValue,
            };

            property.PropertiesForRent.Add(propertiesForRent);

            return property;
        }

    }
}
