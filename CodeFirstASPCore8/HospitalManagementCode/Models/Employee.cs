using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;


namespace HospitalManagementCode.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }

        public string? Email_Work { get; set; }

        public string? Email_Personal { get; set; }

        public string? Mobile_Work { get; set; }    //Phone /Mobile /Contact

        public string? Mobile_Personal { get; set; }

        public bool? IsClinician { get; set; }

        public DateOnly? HireDate { get; set; }

        public bool? IsActive { get; set; }

        // Assuming an Employee can be associated with one HCP
        public int HCPId { get; set; }  // Explicit foreign key

        [ForeignKey("HCPId")]
        public Int64 HCP { get; set; }  // Navigation property

        // Navigation properties
        public virtual PersonName? EmployeeName { get; set; }

        // One-to-one relationships with Address for Home and Work addresses
        public virtual Address? HomeAddress { get; set; }
        public virtual Address? WorkAddress { get; set; }

        // Foreign key properties
        public long? HomeAddressId { get; set; }
        public long? WorkAddressId { get; set; }

        // Navigation properties
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
