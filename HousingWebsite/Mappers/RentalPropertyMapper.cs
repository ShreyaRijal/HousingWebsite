using HousingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingWebsite.Mappers
{
    public static class RentalPropertyMapper
    {
        public static RentalPropertyViewModel MapPropertyToRentalPropertyVM(Property property)
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

            return propertyViewModel;
        }
    }
}
