using Microsoft.AspNetCore.Mvc;
using ProjectIdentity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIdentity.Controllers
{
    public class SkillController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SkillController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
