using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcEmployee;
using NUnit.Framework;
using EntitiesLibrary;
using EmployeeListLibrary;

namespace ClassLibraryforMvcEmployee.Tests
{
    [TestFixture]
    public class TestAdd
    {
        IList<Employee> empList;

        [SetUp]
        public void Init()
        {
            empList = new List<Employee>();
            empList = EmployeeListLibrary.EmployeeList.ConstructEmployeesList();
        }

        [Test]
        public void TestCreate()
        {
            //arrange
            
            var initialCount = empList.Count();

            //act
            var newEmployee = new Employee();
            newEmployee.Id = 7;
            newEmployee.FirstName = "Ana";
            newEmployee.LastName = "Maier";
            newEmployee.Salary = 200;
            newEmployee.Manager = null;
            empList.Add(newEmployee);

            var finalCount = empList.Count;

            //assert
            Assert.AreEqual(initialCount + 1, finalCount);
        }
    }
}
