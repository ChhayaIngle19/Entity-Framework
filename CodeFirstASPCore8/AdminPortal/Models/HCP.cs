//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace AdminPortal.Models
//{
//    public class HCP
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public long Id { get; set; }

//        [Timestamp]
//        public byte[]? TimeStamp { get; set; }

//        [Required, MaxLength(100)]
//        public string? Name { get; set; }

//        public bool? IsRootUserIdEnabled { get; set; }

//        public bool? IsSecretKeyEnabled { get; set; }

//        public bool? IsLicenseKeyActivated { get; set; }

//        public bool? AreSecretQuestionsSetup {  get; set; }

//        public DateTime? CreatedTimestamp { get; set; }
//        public DateTime? UpdatedTimestamp { get; set; }

//        // Navigation properties
//        public virtual Region? Region { get; set; }

//        public long? EmployeeId { get; set; }
//        [ForeignKey("EmployeeId")]
//        public ICollection<Employee> Employee { get; set; } = new List<Employee>();

//        public virtual Employee? PrimaryAdmin { get; set; }

//        public virtual Employee? PrimaryInformationAnalyst { get; set; }

//        public virtual ICollection<Employee> SecondaryAdmin { get; set; } = new List<Employee>();
//        //public Employee? SecondaryAdmin { get; set; }

//        public virtual ICollection<Employee> SecondaryInformationAnalyst { get; set; } = new List<Employee>();
//        //public Employee? SecondaryInformationAnalyst { get; set; }

//        public virtual Address? Address { get; set; }


//    }
//}
