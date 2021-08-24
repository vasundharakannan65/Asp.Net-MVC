using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankProject.Models
{
    public enum Gender
    {
        Female = 1,
        Male = 2
    }

    public class Customer
    {

        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage = "The customer name is not valid, use alphabets only")]
        [DisplayName("Name")]
        public string CustName { get; set; }

        [Required]
        [DisplayName("Address")]
        [StringLength(20,ErrorMessage ="The customer address is not valid")]
        public string CustAddress{ get; set; }

        [Required]
        [DisplayName("Age")]
        [Range(18,25,ErrorMessage ="The customer must be of age between 18-25")]
        public int CustAge { get; set; }

        [Required]
        [DisplayName("Gender")]
        //[RegularExpression("^[M|m|F|f]",ErrorMessage ="The customer gender must be of 'F' / 'f' / 'm' / 'M' ")]
        public Gender CustGender { get; set; }

        [Required]
        [DisplayName("Open Balance")]
        [Range(100,1000,ErrorMessage ="The minimum of balance Rs.100 & maximum of Rs.1000 required")]
        public double CustBlnc { get; set; }
    }
}
