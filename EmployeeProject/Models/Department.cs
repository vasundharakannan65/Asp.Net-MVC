using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Models
{

    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        [StringLength(50)]
        public string DeptName { get; set; }
    }
}
