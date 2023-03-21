using EMS_Web_Application.Models;

namespace EMS_Web_Application.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> ListAllDepartments();
        Department GetById(int Id);
        Department AddDepartment(Department newDepartment);
        Department EditDepartment(Department newDepartment, int departmentId);
        Department DeleteDepartment(int departmentId);    

    }
}
