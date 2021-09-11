using HomeWork_20.Data;
using HomeWork_20.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ApplicationDbContext _db;
        public ShoppingCartController(ShoppingCart shoppingCart, ApplicationDbContext db)
        {
            _shoppingCart = shoppingCart;
            _db = db;
        }
        public ViewResult Index()
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            ViewBag.isLogin = false;
            ViewBag.isRegister = false;

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int? id)
        {
            var selectedCourse = _db.Courses.FirstOrDefault(c => c.Id == id);

            if (selectedCourse != null)
            {
                _shoppingCart.AddToCart(selectedCourse);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int courseId)
        {
            var selectedCourse = _db.Courses.FirstOrDefault(c => c.Id == courseId);

            if (selectedCourse != null)
            {
                _shoppingCart.RemoveFromCart(selectedCourse);
            }

            return RedirectToAction("Index");
        }
    } 
}
