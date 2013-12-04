using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLibrary;

namespace BusinessLogicLibrary
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        void Delete(Int64 id);
        IList<Employee> GetAll();
        Employee GetById(Int64 id);
        Employee CreatEmployee(string firstName, string lastName, Double salary, Int64 managerId);
    }
}
