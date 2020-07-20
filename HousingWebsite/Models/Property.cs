using System;
using System.Collections.Generic;

namespace HousingWebsite.Models
{
    public partial class Property
    {
        //public Property()
        //{
        //    PropertiesForRent = new HashSet<PropertiesForRent>();
        //}

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
        public string PhotoRef { get; set; }

        public virtual PropertiesForRent PropertiesForRent { get; set; }
        //public virtual ICollection<PropertiesForRent> PropertiesForRent { get; set; }
    }
}
