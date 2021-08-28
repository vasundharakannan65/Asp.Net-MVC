using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIdentity.Models
{
    public class Skill
    {   
        [Key]
        [DisplayName("Skill Id")]
        public int skillId { get; set; }

        [Required]
        [DisplayName("Skill Name")]
        public string skillName { get; set; }
    }
}
