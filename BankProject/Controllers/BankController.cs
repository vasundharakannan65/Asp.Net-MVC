using BankProject.Data;
using BankProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BankProject.Controllers
{
    public class BankController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BankController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> customerList = _db.Customers;

            return View(customerList);
        }

        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(customer);
        } 

        public IActionResult Update(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var customer = _db.Customers.FirstOrDefault(x => x.Id == id);

            if(customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public IActionResult Delete(int? id)
        {
            var customer = _db.Customers.Find(id);
            if(customer == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        } 




    }
}
