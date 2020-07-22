using HousingWebsite.Models;
using System.Linq;

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
                Garden = ConvertBoolToYesNo(property.Garden),
                Parking = ConvertBoolToYesNo(property.Parking),
                Epcrating = property.Epcrating,
                RentalId = property.PropertiesForRent.First().RentalId,
                PricePcm = property.PropertiesForRent.First().PricePcm,
                PetsAllowed = ConvertBoolToYesNo(property.PropertiesForRent.First().PetsAllowed),
                PropertyAvailableFrom = property.PropertiesForRent.First().PropertyAvailableFrom,
                PropertyPhotos = property.PhotoRef
            };

            return propertyViewModel;
        }

        private static string ConvertBoolToYesNo(bool? value)
        {
            if (value.HasValue)
            {
                return (bool)value ? "Yes" : "No";
            }
            return "Unknown";
        }
    }
}
