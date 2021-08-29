using Microsoft.AspNetCore.Mvc;
using ProjectIdentity.Data;
using ProjectIdentity.Models;
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

        //read
        public IActionResult Index()
        {
            IEnumerable<Skill> skillList = _db.Skills;

            return View(skillList);
        }

        //create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {

            var skillset = (from x in _db.Skills
                            where x.SkillName.ToLower() == skill.SkillName.ToLower()
                            select x).ToList();

            if (ModelState.IsValid)
            {
                if (skillset.Count > 0)
                {
                    ViewBag.Duplicate = skill.SkillName + " skill already exist";
                }
                else
                {
                    _db.Skills.Add(skill);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(skill);

        }


        //update
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = _db.Skills.FirstOrDefault(x => x.SkillId == id);

            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _db.Skills.Update(skill);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skill);
        }


        //delete
        public IActionResult Delete(int? id)
        {
            var skill = _db.Skills.FirstOrDefault(x => x.SkillId == id);

            if (skill == null)
            {
                return NotFound();
            }

            _db.Skills.Remove(skill);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
