using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CardSample.Server.Models;

namespace CardSample.Server.ViewModels
{
    public class DepartmentViewModel : ViewModelBase
    {
        public DepartmentViewModel()
        {
            
        }

        public DepartmentViewModel(Department model)
        {
            DepartmentName = model.DepartmentName;
            Location = model.Location;
            DepartmentHead = model.DepartmentHead;

            if (model.Employees != null && model.Employees.Count > 0)
            {
                Employees = model.Employees.ToList().ConvertAll(x => new EmployeeViewModel(x));
            }
        }

        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string DepartmentHead { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }
    }
}