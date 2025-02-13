using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using AdminPortal.Enums;

namespace AdminPortal.Models
{
    public class PersonName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Timestamp]
        public byte[]? TimeStamp { get; set; }

        public NamePrefixType? Prefix { get; set; }

        [Required, MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required, MaxLength(50)]
        public string? LastName { get; set; }

        public NameSuffixType? Suffix { get; set; }

        public DateTime? CreateTimeStamp { get; set; }
        public DateTime? UpdateTimeStamp { get; set; }

        //Foreign Key
        [ForeignKey("EmployeeId")]
        public long? EmployeeId { get; set; }

        //Navigation properties
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();


    }
}
