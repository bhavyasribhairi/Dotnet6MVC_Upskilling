using System.ComponentModel.DataAnnotations;

namespace MVC6Youtube.Models
{


    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }

        public string Designation { get; set; }

        public string Phone { get; set; }
    }
}
