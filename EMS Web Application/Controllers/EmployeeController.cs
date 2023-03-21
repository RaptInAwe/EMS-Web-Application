using Microsoft.AspNetCore.Mvc;
using EMS_Web_Application.Models;
using System.Numerics;
using EMS_Web_Application.Repository;
using EMS_Web_Application.Repository.InitializedMemory;

namespace EMS_Web_Application.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository _repo;          // creation of a field in this interface

        public EmployeeController(IEmployeeRepository repo)         // creating var repo with datatype interface IemployeeRepository
        {
            this._repo = repo;          // injecting the var repo inside the field _repo which is the created field under IEmployee repository
        }
        public IActionResult ListAllEmployees()
        {
            var employeeList = _repo.ListAllEmployees();        // variable here having the function, and field which is created on the interface
            return View(employeeList);
        }
        public IActionResult DeleteEmployee(int employeeId)
        {
            var employeeList = _repo.DeleteEmployee(employeeId);
            return RedirectToAction(controllerName: "Employee", actionName: "ListAllEmployees");
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                var employee = _repo.AddEmployee(newEmployee);
                return RedirectToAction("ListAllEmployees");
            }
            ViewData["Message"] = "Invalid data to add an employee.";
            return View("Add");
        }


        [HttpGet]
        public IActionResult EditEmployee(int employeeId)
        {
            var oldEmployee = _repo.GetById(employeeId);
            return View("Update", oldEmployee);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee newEmployee)
        {
            var employee = _repo.EditEmployee(newEmployee, newEmployee.Id);
            return RedirectToAction("ListAllEmployees");
        }

    }
}
