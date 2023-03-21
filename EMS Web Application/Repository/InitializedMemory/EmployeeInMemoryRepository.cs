using EMS_Web_Application.Models;
using EMS_Web_Application.Repository.InitializedMemory;

namespace EMS_Web_Application.Repository.InitializedMemory
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
        
        {
        static List<Employee> employeeList = new List<Employee>();          // in short this is you initializing a value for that variable you created inside your list object that you can then further access and variably change

        static EmployeeInMemoryRepository()
        {
            employeeList.Add(new Employee(1, "adie", DateTime.Now, "adie@gmail.com", "09948535925", "Marketing"));
            employeeList.Add(new Employee(2, "adie", DateTime.Now, "adie@gmail.com", "09948535925", "Marketing"));

        }

        public List<Employee> ListAllEmployees()
        {
            return employeeList;
        }

        public Employee GetById(int id)
        {
            return employeeList.FirstOrDefault(x => x.Id == id);
        }

        public Employee AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = employeeList.Max(x => x.Id) + 1; 
            employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee EditEmployee(Employee newEmployee, int employeeId)
        {
            var oldEmployee = employeeList.Find(x => x.Id == employeeId);
            if (oldEmployee == null)
                return null;
            employeeList.Remove(oldEmployee);
            employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee DeleteEmployee(int employeeId)
        {
            var oldEmployee = employeeList.Find(x => x.Id == employeeId);
            if (oldEmployee == null)
                return null;
            employeeList.Remove(oldEmployee);
            return oldEmployee;
        }

       
    }
}