using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdminPortal.Enums;
namespace AdminPortal.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Timestamp]
        public byte[]? TimeStamp { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public GenderType? Gender { get; set; }

        [MaxLength(254)]
        public string? Email_Work { get; set; }

        [MaxLength(254)]
        public string? Email_Personal { get; set; }

        [MaxLength(20)]
        public string? Mobile_Work { get; set; }    //Phone /Mobile /Contact

        [MaxLength(20)]
        public string? Mobile_Personal { get; set; }

        public bool IsClinician { get; set; }

        public DateOnly HireDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedTimestamp { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }

        //navigation properties
        public virtual PersonName EmployeeName { get; set; }

        public ICollection<Address>? Address { get; set; }
        // One-to-one relationships with Address for Home and Work addresses
        public virtual Address? HomeAddress { get; set; }

        public virtual Address? WorkAddress { get; set; }
    }
}
