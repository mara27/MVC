using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using EntitiesLibrary;
using EmployeeListLibrary;
using MvcEmployee.Models;

namespace MvcEmployee
{
    public class EntityToModel
    {
        IEmployeeService _employeeService = new EmployeeService(new SessionRepository());

        public IList<EmployeeModel> GetEmployeesModelList()
        {
            
            IList<EmployeeModel> _employeesModel = new List<EmployeeModel>();
            foreach (var emp in _employeeService.GetAll())
            {
                if (emp.Manager != null)
                    _employeesModel.Add(new EmployeeModel(emp.Id, emp.FirstName, emp.LastName, emp.Salary, emp.Manager.FullName));
                else
                    _employeesModel.Add(new EmployeeModel(emp.Id, emp.FirstName, emp.LastName, emp.Salary, null));
            }

            return _employeesModel;
        }

    }
}
