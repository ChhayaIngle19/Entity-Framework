using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
    }
}
