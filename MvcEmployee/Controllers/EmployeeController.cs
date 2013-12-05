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
            var employee = new EmployeeModel();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            _employeeService.Add(_employeeService.CreatEmployee(employee.FirstName, employee.LastName, employee.Salary, employee.ManagerId));
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
            return View(_employeeService.GetById(id));
            //IList<EmployeeModel> employeesListSession = (IList<EmployeeModel>)Session["employeesListModelSession"];
            //EmployeeModel emp = employeesListSession.FirstOrDefault(x => x.Id == id);
            //if(emp == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(emp);
        }

        public ActionResult Edit(int id)
        {
            EmployeeModel empModel = entityToModel.GetEmployeeModel(_employeeService.GetById(id));

            return View(empModel);
            //IList<EmployeeModel> employeesListSession = (IList<EmployeeModel>)Session["employeesListModelSession"];
            //EmployeeModel emp = employeesListSession.FirstOrDefault(x => x.Id == id);
            //if(emp == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel empModel)
        {
            //_employeeService.Add(empModel);
            return RedirectToAction("Index");
        }
    }
}
