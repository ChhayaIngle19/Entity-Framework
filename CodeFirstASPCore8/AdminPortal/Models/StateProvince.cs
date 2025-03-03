using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPortal.Models
{
    public class StateProvince
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [TypeConverter(typeof(Int64Converter))]
        public Int64? Id { get; set; }

        [Timestamp]
        public byte[]? Timestamp { get; set; }

        [Required, MaxLength(30)]
        public string? Name { get; set; }

        [MaxLength(6)]
        public string? Abbr { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow; // Auto-set on insert

        public DateTime UpdatedTimestamp { get; set; } = DateTime.UtcNow; // Auto-set on insert and update


        // Foreign Key and Navigation property
        public long? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }

        //public long? RegionId { get; set; }
        //[ForeignKey("RegionId")]
        //public virtual Region? Region { get; set; }

        //// A StateProvince can have multiple hospitals
        //public virtual ICollection<Hospital> Hospital { get; set; } = new List<Hospital>();

    }
}
