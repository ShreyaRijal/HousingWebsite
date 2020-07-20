using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public bool? Garden { get; set; }
        public bool? Parking { get; set; }
        public string Epcrating { get; set; }
        public int RentalId { get; set; }
        public int? PricePcm { get; set; }
        public bool? PetsAllowed { get; set; }
        public DateTime? PropertyAvailableFrom { get; set; }
        public string PropertyPhotos { get; set; }
    }
}
