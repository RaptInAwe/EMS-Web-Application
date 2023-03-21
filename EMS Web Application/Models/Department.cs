namespace EMS_Web_Application.Models
{
    public class Department
    {

        public int Id { get; set; } 
        public string Name { get; set; }

        public Department() { }
        public Department(int id, string name) 
        {
            Id = id;    
            Name = name;    
        }

        public int DepartmentId { get; set; }
        public Employee Employee { get; set; }

    }
}
