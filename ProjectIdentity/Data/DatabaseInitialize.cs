using Microsoft.AspNetCore.Identity;
using ProjectIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIdentity.Data
{
    public class DatabaseInitialize
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseInitialize(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {

            _roleManager.CreateAsync(new IdentityRole("Admin"));
            _roleManager.CreateAsync(new IdentityRole("Customer"));

        }

    }
}
