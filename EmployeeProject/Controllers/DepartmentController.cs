using EmployeeProject.Data;
using EmployeeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Department> departmentList = _db.Departments;

            return View(departmentList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(department);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _db.Departments.FirstOrDefault(x => x.DeptId == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Update(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public IActionResult Delete(int? id)
        {
            var department = _db.Departments.FirstOrDefault(x => x.DeptId == id);

            if (department == null)
            {
                return NotFound();
            }

            _db.Departments.Remove(department);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
