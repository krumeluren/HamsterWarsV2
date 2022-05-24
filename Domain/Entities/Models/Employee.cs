using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public int Age { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}