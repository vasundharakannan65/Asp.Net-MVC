using EmployeeProject.Data;
using EmployeeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _db.Employees.Where(x => x.Status == 'A').ToList();

            return View(employeeList);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> department = _db.Departments.Select(x => new SelectListItem
            {
                Text = x.DeptName,
                Value = x.DeptId.ToString()

            });

            ViewBag.myDropdown = department;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public IActionResult Update(int? id)
        {
            IEnumerable<SelectListItem> department = _db.Departments.Select(x => new SelectListItem
            {
                Text = x.DeptName,
                Value = x.DeptId.ToString()

            });

            ViewBag.myDropdown = department;
            if (id == null)
            {
                return NotFound();
            }

            var employee = _db.Employees.FirstOrDefault(x => x.EmpId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
           
            if (ModelState.IsValid)
            {
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            var employee = _db.Employees.FirstOrDefault(x => x.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(employee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
