using HomeWork_20.Data;
using HomeWork_20.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult List()
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = true;

            IEnumerable<Course> objList = _db.Courses;
            return View(objList);
        }

        // GET Add
        public IActionResult Add()
        {
            ViewBag.isAdd = true;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            return View();
        }

        // POST Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Course obj)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(obj);
        }

        // GET Delete
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Courses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Courses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        // GET Update
        public IActionResult Update(int? id)
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Courses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(string courseName, int price, string image, int id)
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;

            var course = _db.Courses.Where(c => c.Id == id).FirstOrDefault();
            course.CourseName = courseName;
            course.Price = price;
            course.Image = image;
 
            _db.SaveChanges();

            return View(course);
        }
    }
}
