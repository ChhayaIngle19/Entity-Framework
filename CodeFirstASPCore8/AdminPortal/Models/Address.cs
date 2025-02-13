using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPortal.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Timestamp]
        public byte[]? TimeStamp { get; set; }

        [Required, MaxLength(100)]
        public string? Line1 { get; set; }

        [MaxLength(100)]
        public string? Line2 { get; set; }

        [Required, MaxLength(50)]
        public string? City { get; set; }

        [Required, MaxLength(50)]
        public string? StateProvince { get; set; }

        [Required, MaxLength(20)]
        public string? ZipPinCode { get; set; }

        [MaxLength(70)]
        public string? Country { get; set; }

        public DateTime? CreatedTimestamp { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }

        // Foreign Key and Navigation Property
        public long? EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        public long? HCPId { get; set; }
        [ForeignKey("HCPId")]
        public virtual HCP? HCP { get; set; }

        public long? HospitalId { get; set; } 
        [ForeignKey("HospitalId")]
        public virtual Hospital? Hospital { get; set; }


        // Navigation property to Employee (linked to either HomeAddress or WorkAddress)
        // public virtual Employee? Employee { get; set; }

        // Navigation Property
        //public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();

        //public virtual ICollection<HCP> HCPs { get; set; } = new List<HCP>();
    }
}
