using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementCode.Models
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdatedTimestamp { get; set; }

        //foreign key
        [ForeignKey("StateProvinceId")]
        public Int64? StateProvinceId { get; set; }

        // Navigation properties
        public virtual ICollection<HCP> HCPs { get; set; } = new List<HCP>();

        public Hospital? RegionHospitals { get; set; }

        public StateProvince? StateProvinces { get; set; }

        public Employee? PrimaryAdmin { get; set; }

        public ICollection<Employee> SecondaryAdmin { get; set; } = new List<Employee>();
        //public Employee? SecondaryAdmin { get; set; }

    }
}
