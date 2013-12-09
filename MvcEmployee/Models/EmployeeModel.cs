using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEmployee.Models
{
    public class EmployeeModel
    {
        public Int64 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Double Salary { get; set; }
        public Int64 ManagerId { get; set; }
        public String ManagerName { get; set; }

        public String FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }

        public EmployeeModel(long id, string firstName, string lastname, double salary, long managerId, string managerName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastname;
            Salary = salary;
            ManagerId = managerId;
            ManagerName = managerName;
        }

        public EmployeeModel() 
        {
            Id = 0;
        }
    }
}