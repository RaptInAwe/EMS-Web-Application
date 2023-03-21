using EMS_Web_Application.Models;
using EMS_Web_Application.Repository.InitializedMemory;

namespace EMS_Web_Application.Repository.InitializedMemory
{
    public class DepartmentInMemoryRepository : IDepartmentRepository
        
        {
        static List<Department> departmentList = new List<Department>();          // in short this is you initializing a value for that variable you created inside your list object that you can then further access and variably change

        static DepartmentInMemoryRepository()
        {
            departmentList.Add(new Department(1, "adie"));
            departmentList.Add(new Department(2, "adie"));

        }
        public List<Department> ListAllDepartments()
        {
            return departmentList;
        }

        public Department GetById(int id)
        {
            return departmentList.FirstOrDefault(x => x.Id == id);
        }
        public Department AddDepartment(Department newDepartment)
        {
            newDepartment.Id = departmentList.Max(x => x.Id) + 1;
            departmentList.Add(newDepartment);
            return newDepartment;
        }

        public Department EditDepartment(Department newDepartment, int departmentId)
        {
            var oldDepartment = departmentList.Find(x => x.Id == departmentId);
            if (oldDepartment == null)
                return null;
            departmentList.Remove(oldDepartment);
            departmentList.Add(newDepartment);
            return newDepartment;
        }
        public Department DeleteDepartment(int departmentId)
        {
            var oldDepartment = departmentList.Find(x => x.Id == departmentId);
            if (oldDepartment == null)
                return null;
            departmentList.Remove(oldDepartment);
            return oldDepartment;
        }
    }
}
