using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPortal.Models
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Timestamp]
        public byte[]? TimeStamp { get; set; }

        [Required, MaxLength(25)]
        public string? Name { get; set; }

        public DateTime? CreatedTimestamp { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }

        //foreign key and navigation property
        public long? HCPId { get; set; }
        [ForeignKey("HCPId")]
        public virtual HCP? HCP { get; set; }

        public virtual Hospital? Hospital { get; set; }

        public virtual StateProvince? StateProvince { get; set; }

        public virtual Employee? PrimaryAdmin { get; set; }

        public virtual ICollection<Employee> SecondaryAdmin { get; set; } = new List<Employee>();
       
    }
}
