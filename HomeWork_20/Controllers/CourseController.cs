using HomeWork_20.Data;
using HomeWork_20.Models;
using Microsoft.AspNetCore.Authorization;
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
            ViewBag.isLogin = false;
            ViewBag.isRegister = false;

            IEnumerable<Course> coursesList = _db.Courses;
            return View(coursesList);
        }

        // GET Add
        public IActionResult Add()
        {
            ViewBag.isAdd = true;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            ViewBag.isLogin = false;
            ViewBag.isRegister = false;

            return View();
        }

        // POST Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Course obj)
        {
            if (ModelState.IsValid)
            {
                await _db.Courses.AddAsync(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(obj);
        }

        // GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = await _db.Courses.FindAsync(id); ;

            if (obj == null)
            {
                return NotFound();
            }

            Task taskRemove = Task.Run(() => _db.Courses.Remove(obj));
            await taskRemove;
            await _db.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // GET Update
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            ViewBag.isLogin = false;
            ViewBag.isRegister = false;

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = await _db.Courses.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Update
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(string courseName, int price, string image, int id)
        //{
        //    ViewBag.isAdd = false;
        //    ViewBag.isHome = false;
        //    ViewBag.isCourses = false;

        //    var course = _db.Courses.Where(c => c.Id == id).FirstOrDefault();
        //    course.CourseName = courseName;
        //    course.Price = price;
        //    course.Image = image;

        //    _db.SaveChanges();

        //    return View(course);
        //}


        // POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Course obj)
        {
            if (ModelState.IsValid)
            {
                Task taskUpdate = Task.Run(() => _db.Courses.Update(obj));
                await taskUpdate;
                await _db.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(obj);
        }
    }
}
