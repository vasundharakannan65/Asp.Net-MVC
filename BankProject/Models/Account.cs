using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankProject.Models
{
    public class Account
    {
        [Required]
        public string AccountType { get; set; }

        //public int AccountNumber { get; set; }

    }
}
