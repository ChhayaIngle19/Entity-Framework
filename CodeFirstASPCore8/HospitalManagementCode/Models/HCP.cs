using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementCode.Models
{
    public class HCP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        public bool? IsSecretKeyEnabled { get; set; }

        public bool? IsLicenseKeyActivated { get; set; }

        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdatedTimestamp { get; set; }

        // Navigation properties
        public Region? HCPRegionId { get; set; }

        public Employee? PrimaryAdmin { get; set; }

        public Employee? PrimaryInformationAnalyst { get; set; }

        public ICollection<Employee> SecondaryAdmin { get; set; } = new List<Employee>();
        //public Employee? SecondaryAdmin { get; set; }

        public ICollection<Employee> SecondaryInformationAnalyst { get; set; } = new List<Employee>();
        //public Employee? SecondaryInformationAnalyst { get; set; }

        public Address? HCPAddress { get; set; }


    }
}
