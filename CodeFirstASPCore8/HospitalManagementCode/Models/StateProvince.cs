using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HospitalManagementCode.Models
{
    public class StateProvince
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string? Name { get; set; }

        public string? Abbr { get; set; }

        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }

        // Foreign Key
        [ForeignKey("CountryId")]
        public Int64? CountryId { get; set; }

        //navigation property
        public Hospital? StateHospitals { get; set; }

    }
}
