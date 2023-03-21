using FluentValidation.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMS_Web_Application.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Department { get; set; }              // property setting for the class model Employee


        public Employee() { } 
        public Employee(int id, string name, DateTime dob, string email, string phone, string department) 
        {
            Id = id;
            Name = name;    
            DOB = dob;  
            Email = email;  
            Phone = phone;  
            Department = department;                        // constructor creation, declaring variables on it, then pushing the properties inside the variables
        }

        public Department DepartmentId { get; set; }

    }
    
}
