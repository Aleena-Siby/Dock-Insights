using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class VesselType
    {
        [Key]
        public string VesselTypeId { get; set; }  // Primary key (vessel_type_id)
        public string VesselTypeName { get; set; }  // Vessel type name
    }
}
