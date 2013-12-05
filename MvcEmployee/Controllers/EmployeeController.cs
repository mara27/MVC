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
            Int64 newId = lastEmployee.Id + 1;
            string newFirstName = Request["FirstName"].ToString();
            string newLastName = Request["LastName"].ToString();
            double newSalary = Convert.ToDouble(Request["Salary"]);
            Int64 newManagerId = Convert.ToInt64(Request["ManagerName"]);
            string newManagerName = "";
            foreach(var emp in employeesListSession)
            {
                if (emp.Id == newManagerId)
                    newManagerName = emp.FullName;

            }
            EmployeeModel newEmployeeModel = new EmployeeModel(newId, newFirstName, newLastName, newSalary, newManagerName);
            employeesListSession.Add(newEmployeeModel);
            Session["employeeListModelSession"] = employeesListSession;
            return RedirectToAction("Index");
        }
    }
}
