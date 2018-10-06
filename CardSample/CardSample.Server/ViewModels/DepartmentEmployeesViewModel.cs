using CardSample.Server.Models;

namespace CardSample.Server.ViewModels
{
    public class DepartmentEmployeesViewModel : EmployeeViewModel
    {
        public DepartmentEmployeesViewModel(Employee model)
        {
            if(model == null) return;
            
            Id = model.Id;
            Name = model.Name;
            Gender = model.Gender;
            GenderName = model.Gender.ToString();
            Salary = model.Salary;
            DepartmentId = model.DepartmentId;
        }
        
    }
}