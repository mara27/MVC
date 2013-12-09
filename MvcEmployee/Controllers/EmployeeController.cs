using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLibrary;
using EntitiesLibrary;
using MvcEmployee.Models;

namespace MvcEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        IEmployeeService _employeeService = new EmployeeService(new SessionRepository());
        EntityToModel entityToModel = new EntityToModel();

        public ActionResult Index()
        {
            var emplist = _employeeService.GetAll();
            var empListModel = entityToModel.GetEmployeesModelList(emplist);

            return View(empListModel);
        }

        public ActionResult Create()
        {
            var emp = new EmployeeModel();

            return View(emp);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel empModel)
        {
            Employee emp = _employeeService.CreatEmployee(empModel.FirstName, empModel.LastName, empModel.Salary, empModel.ManagerId);
            _employeeService.Add(emp);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Employee emp = _employeeService.GetById(id);

            if(emp == null)
            {
                return HttpNotFound();
            }
            else
            {
                EmployeeModel empModel = entityToModel.GetEmployeeModel(emp);

                return View(empModel);
            }
        }

        public ActionResult Delete(int id)
        {
            Employee emp = _employeeService.GetById(id);

            if (emp == null)
            {
                return HttpNotFound();
            }
            else
            {
                _employeeService.Delete(id);

                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Edit(int id)
        {
            var emp = _employeeService.GetById(id);

            if(emp == null)
            {
                return HttpNotFound();
            }
            else
            {
                EmployeeModel empModel = entityToModel.GetEmployeeModel(emp);
               
                return View(empModel);
            }
                     
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel empModel)
        {
            Employee emp = _employeeService.GetById(empModel.Id);
            emp.FirstName = empModel.FirstName;
            emp.LastName = empModel.LastName;
            emp.Salary = empModel.Salary;
            emp.Manager = _employeeService.GetById(empModel.ManagerId);
      
            return RedirectToAction("Index");
        }
    }
}
