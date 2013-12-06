using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLibrary;
using EntitiesLibrary;
using EmployeeListLibrary;
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
            //IList<EmployeeModel> employeesListSession = (IList<EmployeeModel>)Session["employeesListModelSession"];
            //EmployeeModel lastEmployee = employeesListSession.Last();
            //Int64 newEmpId = lastEmployee.Id + 1;
            //string newEmpFirstName = Request["FirstName"].ToString();
            //string newEmpLastName = Request["LastName"].ToString();
            //double newEmpSalary = Convert.ToDouble(Request["Salary"]);
            //Int64 managerId = Convert.ToInt64(Request["ManagerName"]);
            //EmployeeModel manager = employeesListSession.FirstOrDefault(x => x.Id == managerId);
            //string newEmpManagerName = manager.FullName;
            //EmployeeModel newEmployee = new EmployeeModel(newEmpId, newEmpFirstName, newEmpLastName, newEmpSalary, newEmpManagerName);
            //employeesListSession.Add(newEmployee);
            //Session["employeeListModelSession"] = employeesListSession;
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
            
            //IList<EmployeeModel> employeesListSession = (IList<EmployeeModel>)Session["employeesListModelSession"];
            //EmployeeModel emp = employeesListSession.FirstOrDefault(x => x.Id == id);
            //if(emp == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(emp);
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
            //var list = _employeeService.GetAll();
            var emp = _employeeService.GetById(id);
            if(emp == null)
            {
                return HttpNotFound();
            }
            else
            {
                EmployeeModel empModel = entityToModel.GetEmployeeModel(emp);
                //_employeeService.Delete(id);
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
            //emp.Manager.FullName = empModel.ManagerName;

            //var emplist = _employeeService.GetAll();
            //var empListModel = entityToModel.GetEmployeesModelList(emplist);
            //var empEdited = empListModel.Single(emp => emp.Id == empModel.Id);
            //empEdited.FirstName = empModel.FirstName;
            //empEdited.LastName = empModel.LastName;
            //empEdited.Salary = empModel.Salary;
            //empEdited.ManagerName = empModel.ManagerName;

            //Employee emp = _employeeService.CreatEmployee(empModel.FirstName, empModel.LastName, empModel.Salary, empModel.ManagerId);
            //_employeeService.Add(emp);
            return RedirectToAction("Index");
        }
    }
}
