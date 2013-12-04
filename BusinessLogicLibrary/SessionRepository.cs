using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EntitiesLibrary;
using EmployeeListLibrary;

namespace BusinessLogicLibrary
{
    public class SessionRepository : IRepository
    {
        private const String SESSION_KEY = "EMPLOYEE_LIST";

        private IList<Employee> Employees
        {
            get
            {
                if (HttpContext.Current.Session[SESSION_KEY] == null)
                {
                    HttpContext.Current.Session[SESSION_KEY] = EmployeeList.ConstructEmployeesList();
                }
                return (HttpContext.Current.Session[SESSION_KEY] as IList<Employee>);
            }

            set
            {
                HttpContext.Current.Session[SESSION_KEY] = value;
            }
        }

        public void Add(Employee employee)
        {
            var employees = Employees;
            employees.Add(employee);
            Employees = employees;
        }

        public void Delete(long id)
        {
            var employee = GetById(id);
            var employees = Employees;
            employees.Remove(employee);
            Employees = employees;

        }

        public IList<Employee> GetAll()
        {
            return Employees;
        }

        public Employee GetById(long id)
        {
            return Employees.FirstOrDefault(x => x.Id == id);
        }
    }
}
