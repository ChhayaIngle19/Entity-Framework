using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementCode.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string? Line1 { get; set; }

        [MaxLength(100)]
        public string? Line2 { get; set; }

        [Required, MaxLength(50)]
        public string? City { get; set; }

        [Required, MaxLength(50)]
        public string? StateProvince { get; set; }

        [Required, MaxLength(20)]
        public string? ZipPinCode { get; set; }

        [Required, MaxLength(70)]
        public string? Country { get; set; }

        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }

        //Foreign key properties
         public long? HomeEmployeeId { get; set; }
        public long? WorkEmployeeId { get; set; }

        //Navigation properties
        public virtual Employee? HomeEmployee { get; set; }
        public virtual Employee? WorkEmployee { get; set; }

        // Navigation Property
        public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();

        public virtual ICollection<HCP> HCPs { get; set; } = new List<HCP>();
    }
}
