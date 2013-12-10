using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLibrary;


namespace EmployeeListLibrary
{
    public static class EmployeeList
    {

        public static IList<Employee> ConstructEmployeesList()
        {
            var employeesList = new List<Employee>
            {
                new Employee{Id = 1, FirstName = "Mark", LastName = "Abrain", Salary = 1200.00, Manager = null},
                new Employee{Id = 2, FirstName = "Matthew", LastName = "Abrain", Salary = 800.00, Manager = null},
                new Employee{Id = 3, FirstName = "David C", LastName = "Abysalh", Salary = 500.50, Manager = null},
                new Employee{Id = 4, FirstName = "Samuel Max", LastName = "Acott", Salary = 900.00, Manager = null},
                new Employee{Id = 5, FirstName = "Adams", LastName = "Christopher ", Salary = 700.00, Manager = null},
            };

            employeesList[1].Manager = employeesList[0];
            employeesList[2].Manager = employeesList[0];
            employeesList[4].Manager = employeesList[3];
            

            return employeesList;
        }
    }
}
