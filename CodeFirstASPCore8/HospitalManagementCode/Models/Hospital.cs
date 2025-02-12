using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementCode.Models
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required, MaxLength(500)]
        public string? Description { get; set; }

        public string? ProfileImage { get; set; }

        public string? Logo { get; set; }

        public Int16 Beds { get; set; }

        public Int16 InPatientGroupsCount { get; set; }

        public DateTime CreateTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }

        //foreign key
        [ForeignKey("RegionId")]
        public Int64? RegionId { get; set; }

        //navigation properties
        public Employee? PrimaryAdmin { get; set; }

        public ICollection<Employee> SecondaryAdmins { get; set; } = new List<Employee>();
        //public Employee? SecondaryAdmin { get; set; }

        public Address? HospitalAddress { get; set; }

    }
}
