using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Vessel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int ImoNo { get; set; }
        public string VesselCode { get; set; }
        [Column("vessel_type_id")] 
        public string VesselTypeId { get; set; }
        [Column("vessel_subcategory_id")]
        public string VesselSubcategoryId { get; set; }
        [Column("port_of_registry")] 
        public string PortOfRegistry { get; set; }
         [Column("port_of_registry_name")] 
        public string PortOfRegistryName { get; set; }
        [Column("country_id")] 
        public string CountryId { get; set; } 
    [Column("official_no")]
        public string OfficialNo { get; set; }
        [Column("communication_info")]
        public string CommunicationInfo { get; set; }
    [Column("key_dates")]
        public string KeyDates { get; set; }

        public int Status { get; set; }
        [Column("vessel_type_name")]
        public string VesselTypeName { get; set; }

         [Column("vessel_subcategory_name")]
        public string VesselSubcategoryName { get; set; }
        
        [Column("group_owner_name")]
        public string GroupOwnerName { get; set; }
          [Column("vessel_subcategory_short_name")]
        public string VesselSubcategoryShortName { get; set; }

        public string Country { get; set; }
         [Column("last_dd_date")]
        public DateTime LastDdDateOnly
    {
        get => LastDdDateOnly.Date;  // Only the date part (YYYY-MM-DD)
        set => LastDdDateOnly = value.Date;  // Store only the date part in the original DateTime property
    }   
        [Column("dd_due_date")]
        public DateTime DdDueDateOnly
    {
        get => DdDueDateOnly.Date;
        set => DdDueDateOnly = value.Date;
    }
    }
}
