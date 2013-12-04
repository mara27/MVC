using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLibrary;

namespace BusinessLogicLibrary
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;

        public EmployeeService(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(Employee employee)
        {
            if (employee.Id == 0)
            {
                employee.Id = GetNextId();
            }
            else
            {
                _repository.Delete(employee.Id);
            }
            _repository.Add(employee);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public IList<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public Employee GetById(long id)
        {
            return _repository.GetById(id);
        }

        public Employee CreatEmployee(string firstName, string lastName, double salary, long managerId)
        {
            return new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary,
                Manager = _repository.GetById(managerId)
            };
        }

        private long GetNextId()
        {
            return _repository.GetAll().Max(x => x.Id) + 1;
        }
    }
}
