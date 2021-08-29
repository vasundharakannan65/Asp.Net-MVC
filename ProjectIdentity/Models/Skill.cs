using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIdentity.Models
{
    public class Skill
    {   
        [Key]
        [DisplayName("Skill Id")]
        public int SkillId { get; set; }

        [Required]
        [DisplayName("Skill Name")]
        public string SkillName { get; set; }


        //Navigation properties

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
