using EMS_Web_Application.Models;

namespace EMS_Web_Application.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> ListAllEmployees();
        Employee GetById(int id);   
        Employee AddEmployee(Employee newEmployee);
        Employee EditEmployee(Employee newEmployee, int employeeId);    
        Employee DeleteEmployee(int employeeId);            // contract, list's objects, tagging functions on it in order - to-call interface for CRUD operations
    }
}
