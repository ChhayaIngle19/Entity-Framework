using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace HospitalManagementCode.Models
{
    public class PersonName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        public PrefixOrigin? NamePrefixType { get; set; }

        [Required, MaxLength(50)]
        public string? FirstName { get; set; }

        [Required, MaxLength(50)]
        public string? MiddleName { get; set; }

        public SuffixOrigin? NameSuffixType { get; set; }

        [Required, MaxLength(50)]
        public string? LastName { get; set; }

        public DateTime CreateTimeStamp { get; set; }
        public DateTime LastUpdateTimeStamp { get; set; }

        //Foreign Key
        [ForeignKey("EmployeeId")]
        public Int64? EmployeeId { get; set; }

        //Navigation properties
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        

    }
}
