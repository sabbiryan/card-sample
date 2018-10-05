﻿using CardSample.Server.Models;

namespace CardSample.Server.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {

        public EmployeeViewModel()
        {
            
        }

        public EmployeeViewModel(Employee model)
        {
            Name = model.Name;
            Gender = model.Gender;
            GenderName = model.ToString();
            Salary = model.Salary;
            DepartmentId = model.DepartmentId;

            if (model.Department != null)
            {
                Department = new DepartmentViewModel(model.Department);
            }
        }

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string GenderName { get; set; }
        public decimal Salary { get; set; }

        public string DepartmentId { get; set; }
        public virtual DepartmentViewModel Department { get; set; }
    }
}