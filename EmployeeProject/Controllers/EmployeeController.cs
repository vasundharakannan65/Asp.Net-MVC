using EmployeeProject.Data;
using EmployeeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index(string sortOrder,string searchString, int page = 1)
        {
            //sorting
            var empList = _db.Employees.Include("Dept").Where(e => e.Status == 'A');

            ViewData["IdSortParam"] = sortOrder == "idDesc" ? "idAsc" : "idDesc";
            ViewData["NameSortParam"] = sortOrder == "nameDesc" ? "nameAsc" : "nameDesc";
            ViewData["DesignationSortParam"] = sortOrder == "designationDesc" ? "designationAsc" : "designationDesc";
            ViewData["DeptNameSortParam"] = sortOrder == "deptNameDesc" ? "deptNameAsc" : "deptNameDesc";
            ViewData["DateSortParam"] = sortOrder == "dateDesc" ? "dateAsc" : "dateDesc";


            switch (sortOrder)
            {
                case "idAsc":
                    empList = empList.OrderBy(x => x.EmpId);
                    break;
                case "idDesc":
                    empList = empList.OrderByDescending(x => x.EmpId);
                    break;
                case "nameAsc":
                    empList = empList.OrderBy(x => x.EmpName);
                    break;
                case "nameDesc":
                    empList = empList.OrderByDescending(x => x.EmpName);
                    break;
                case "designationAsc":
                    empList = empList.OrderBy(x => x.EmpDesignation);
                    break;
                case "designationDesc":
                    empList = empList.OrderByDescending(x => x.EmpDesignation);
                    break;
                case "deptNameAsc":
                    empList = empList.Include("Dept").OrderBy(d => d.Dept.DeptName);
                    break;
                case "deptNameDesc":
                    empList = empList.Include("Dept").OrderByDescending(d => d.Dept.DeptName);
                    break;
                case "Date":
                    empList = empList.OrderBy(x => x.HireDate);
                    break;
                case "dateDesc":
                    empList = empList.OrderByDescending(x => x.HireDate);
                    break;
                default:
                    empList = empList.OrderBy(x => x.EmpId);
                    break;
            }


            //searching 
            ViewData["CurrentFilter"] = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                empList = empList.Where(s => s.EmpName.ToLower().Contains(searchString.ToLower()));
            }

            //paging
            var paginatedResult = PaginatedResult(empList.ToList(), page, 10);

            dynamic obj = new ExpandoObject();

            obj.empList = paginatedResult;

            ViewBag.Data = obj;

            return View();

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
           
            if (ModelState.IsValid && employee != null)
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
