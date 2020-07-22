using System;

namespace HousingWebsite.Models
{
    public class RentalPropertyViewModel
    {
        public int PropertyId { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string PropertyType { get; set; }
        public DateTime? BuildDate { get; set; }
        public int? NoOfBedrooms { get; set; }
        public string Garden { get; set; }
        public string Parking { get; set; }
        public string Epcrating { get; set; }
        public int RentalId { get; set; }
        public int? PricePcm { get; set; }
        public string PetsAllowed { get; set; }
        public DateTime? PropertyAvailableFrom { get; set; }
        public string PropertyPhotos { get; set; }
    }
}
