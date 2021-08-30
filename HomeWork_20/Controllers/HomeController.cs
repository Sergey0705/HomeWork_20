using HomeWork_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            ViewBag.isHome = true;
            ViewBag.isCourses = false;
            ViewBag.isAdd = false;

            return View();
        }
        public IActionResult Courses()
        {
            ViewBag.isHome = false;
            ViewBag.isCourses = true;
            ViewBag.isAdd = false;

            return View();
        }
        public IActionResult Add()
        {
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            ViewBag.isAdd = true;

            return View();
        }
    }
}
