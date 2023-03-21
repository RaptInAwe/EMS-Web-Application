using EMS_Web_Application.Models;
using EMS_Web_Application.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Web_Application.Controllers
{
    public class DepartmentController :Controller
    {
        IDepartmentRepository _repo;          // creation of a field in this interface

        public DepartmentController(IDepartmentRepository repo)         // creating var repo with datatype interface IemployeeRepository
        {
            this._repo = repo;          // injecting the var repo inside the field _repo which is the created field under IEmployee repository
        }
        public IActionResult ListAllDepartments()
        {
            var departmentList = _repo.ListAllDepartments();        // variable here having the function, and field which is created on the interface
            return View(departmentList);
        }
        public IActionResult DeleteDepartment(int departmentId)
        {
            var departmentList = _repo.DeleteDepartment(departmentId);
            return RedirectToAction(controllerName: "Department", actionName: "ListAllDepartments");
        }



        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult AddDepartment(Department newDepartment)
        {
            if (ModelState.IsValid)
            {
                var department = _repo.AddDepartment(newDepartment);
                return RedirectToAction("ListAllDepartments");
            }
            ViewData["Message"] = "Invalid data to add department.";
            return View("Add");
        }


        [HttpGet]
        public IActionResult EditDepartment(int employeeId)
        {
            var oldDepartment = _repo.GetById(employeeId);
            return View("Update", oldDepartment);
        }
        [HttpPost]
        public IActionResult EditDepartment(Department newDepartment)
        {
            var employee = _repo.EditDepartment(newDepartment, newDepartment.Id);
            return RedirectToAction("ListAllDepartments");
        }
    }
}
