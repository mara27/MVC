using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLibrary;

namespace MvcEmployee.Models
{
    public class EmployeeModel
    {
        public Int64 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Double Salary { get; set; }
        public String ManagerName { get; set; }

        public String FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }

        public EmployeeModel(Int64 id, string firstName, string lastname, double salary, string managerName) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastname;
            Salary = salary;
            ManagerName = managerName;
        }

        public EmployeeModel() { }
    }
}