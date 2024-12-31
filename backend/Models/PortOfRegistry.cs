using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class PortOfRegistry
    {
        [Key]
        public string PortOfRegistryId { get; set; }  // Primary key (port_of_registry)
        public string PortOfRegistryName { get; set; }  // Port of registry name
    }
}
