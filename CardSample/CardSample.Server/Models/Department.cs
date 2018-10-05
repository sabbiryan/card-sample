using System.Collections.Generic;

namespace CardSample.Server.Models
{
    public class Department : EntityBase
    {
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string DepartmentHead { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}