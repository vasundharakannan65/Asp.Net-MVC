using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Models
{
    public enum Designation
    {
        Manager = 1,
        Developer = 2,
        Admin = 3,
        CEO = 4
    }

    public class Employee
    {
        //Id,  Name,  Designation, Department ID, Hire Date

        [Key]
        public int EmpId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please Use Alphabets Only")]
        [Display(Name = "Name")]
        public string EmpName { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public Designation EmpDesignation { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public char Status { get; set; } = 'A';


        [Required(ErrorMessage = "The Department ID is required")]
        [ForeignKey("Department")]
        public int DeptId { get; set; }


        public Department Dept { get; set; }
    }
}
