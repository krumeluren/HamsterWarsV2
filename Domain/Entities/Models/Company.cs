
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
