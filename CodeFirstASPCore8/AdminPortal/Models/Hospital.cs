using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPortal.Models
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required, MaxLength(500)]
        public string? Description { get; set; }

        public string? ProfileImage { get; set; }

        public string? Logo { get; set; }

        public short Beds { get; set; }

        public short InPatientGroupsCount { get; set; }

        public DateTime? CreateTimestamp { get; set; }
        public DateTime? UpdateTimestamp { get; set; }

        //foreign key
        public long? RegionId { get; set; }
        [ForeignKey("RegionId")]

        public long? StateProvinceId { get; set; }
        [ForeignKey("StateProvinceId")]
        
        //navigation properties
        public virtual Employee? PrimaryAdmin { get; set; }

        public virtual ICollection<Employee> SecondaryAdmins { get; set; } = new List<Employee>();
        //public Employee? SecondaryAdmin { get; set; }

        public virtual Address? HospitalAddress { get; set; }

    }
}
