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

        public ActionResult Index()
        {
            if (HttpContext.Session["employeesListModelSession"] == null)
            {
                var entityToModel = new EntityToModel();
                var employeesListModel = entityToModel.GetEmployeesModelList();
                HttpContext.Session["employeesListModelSession"] = employeesListModel;
                return View(employeesListModel);
            }

            else
            {
                var empList = Session["employeesListModelSession"];
                return View(empList);
            }

        }

        public ActionResult Create()
        {
            var employee = new EmployeeModel();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            IList<EmployeeModel> employeesListSession = (IList<EmployeeModel>)Session["employeesListModelSession"];
            EmployeeModel lastEmployee = employeesListSession.Last();
            Int64 newEmpId = lastEmployee.Id + 1;
            string newEmpFirstName = Request["FirstName"].ToString();
            string newEmpLastName = Request["LastName"].ToString();
            double newEmpSalary = Convert.ToDouble(Request["Salary"]);
            Int64 managerId = Convert.ToInt64(Request["ManagerName"]);
            EmployeeModel manager = employeesListSession.FirstOrDefault(x => x.Id == managerId);
            string newEmpManagerName = manager.FullName;
            EmployeeModel newEmployee = new EmployeeModel(newEmpId, newEmpFirstName, newEmpLastName, newEmpSalary, newEmpManagerName);
            employeesListSession.Add(newEmployee);
            Session["employeeListModelSession"] = employeesListSession;
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            IList<EmployeeModel> employeesListSession = (IList<EmployeeModel>)Session["employeesListModelSession"];
            EmployeeModel emp = employeesListSession.FirstOrDefault(x => x.Id == id);
            if(emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }
    }
}
