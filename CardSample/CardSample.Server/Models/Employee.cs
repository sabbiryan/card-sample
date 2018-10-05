using System.ComponentModel.DataAnnotations.Schema;

namespace CardSample.Server.Models
{
    public class Employee : EntityBase
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }

        public string DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}