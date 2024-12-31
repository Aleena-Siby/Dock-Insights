using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class VesselSubcategory
    {
        [Key]
        public string VesselSubcategoryId { get; set; }  // Primary key (vessel_subcategory_id)
        public string VesselSubcategoryName { get; set; }  // Vessel subcategory name
        public string VesselSubcategoryShortName { get; set; }  // Vessel subcategory short name
    }
}
