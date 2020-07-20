using System;
using System.Collections.Generic;

namespace HousingWebsite.Models
{
    public partial class PropertiesForRent
    {
        public PropertiesForRent()
        {
            Property = new HashSet<Property>();
        }

        public int RentalId { get; set; }
        public int PropertyId { get; set; }
        public int? PricePcm { get; set; }
        public bool? PetsAllowed { get; set; }
        public DateTime? PropertyAvailableFrom { get; set; }

        //public virtual Property Property { get; set; }

        public virtual ICollection<Property> Property { get; set; }

    }
}
