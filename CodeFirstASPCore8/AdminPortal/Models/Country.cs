using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdminPortal.Enums;
namespace AdminPortal.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[TypeConverter(typeof(Int64Converter))]
        public Int64? Id { get; set; }

        [Timestamp]
        public byte[]? Timestamp { get; set; }

        [MaxLength(70)]
        public string? Name { get; set; }    //country name

        [MaxLength(10)]
        public required string Abbr { get; set; }   // Unique country abbreviation  

        [MaxLength(8)]
        public string? CountryCode { get; set; }

        public ContinentType? Continent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow; // Auto-set on insert

        public DateTime UpdatedTimestamp { get; set; } = DateTime.UtcNow; // Auto-set on insert and update


        //public DateTime? CreatedTimestamp { get; set; }
        //public DateTime? UpdatedTimestamp { get; set; }

        // Navigation property: the country might have a related StateProvince (nullable)
        // public virtual ICollection<StateProvince> StateProvince { get; set; }


    }
}
