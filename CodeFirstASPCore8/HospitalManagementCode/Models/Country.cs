using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementCode.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required, MaxLength(70)]
        public string? Name { get; set; }    //country name

        [Required, MaxLength(10)]
        public string? Abbr { get; set; }

        [Required, MaxLength(8)]
        public string? CountryCode { get; set; }

        public string? Continent { get; set; }

        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }

        // Navigation property: the country might have a related StateProvince (nullable)
        
        // public StateProvince? CountryStateProvinces { get; set; }
        public ICollection<StateProvince>? CountryStateProvinces { get; set; }


    }
}
