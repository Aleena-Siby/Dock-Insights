using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Country
    {
        [Key]
        public string CountryId { get; set; }  // Primary key (country_id)
        public string CountryName { get; set; }  // Country name
    }
}
