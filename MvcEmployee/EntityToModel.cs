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
        //IEmployeeService _employeeService = new EmployeeService(new SessionRepository());

        public EmployeeModel GetEmployeeModel(Employee emp)
        {
            EmployeeModel empModel;
            if (emp.Manager != null)
                empModel = new EmployeeModel(emp.Id, emp.FirstName, emp.LastName, emp.Salary, emp.Manager.Id, emp.Manager.FullName);
            else
                empModel = new EmployeeModel(emp.Id, emp.FirstName, emp.LastName, emp.Salary, 0, null);

            return empModel;
        }

        public IList<EmployeeModel> GetEmployeesModelList(IList<Employee> empList)
        {

            IList<EmployeeModel> _employeesModel = new List<EmployeeModel>();
            foreach (var emp in empList)
            {
                    _employeesModel.Add(GetEmployeeModel(emp));
                //    _employeesModel.Add(new EmployeeModel(emp.Id, emp.FirstName, emp.LastName, emp.Salary, emp.Manager.Id, emp.Manager.FullName));
                //else
                //    _employeesModel.Add(new EmployeeModel(emp.Id, emp.FirstName, emp.LastName, emp.Salary, 0, null));
            }

            return _employeesModel;
        }
    }
}
