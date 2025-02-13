using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPortal.Models
{
    public class StateProvince
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, MaxLength(30)]
        public string? Name { get; set; }

        [MaxLength(6)]
        public string? Abbr { get; set; }

        public DateTime? CreatedTimestamp { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }

        // Foreign Key and Navigation property
        public long? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }

        public long? RegionId { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region? Region { get; set; }

        // A StateProvince can have multiple hospitals
        public virtual ICollection<Hospital> Hospital { get; set; } = new List<Hospital>();

    }
}
