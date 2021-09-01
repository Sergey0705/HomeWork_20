using HomeWork_20.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            ViewBag.isHome = false;
            ViewBag.isAdd = false;
            ViewBag.isCourses = false;

            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            ViewBag.isHome = false;
            ViewBag.isAdd = false;
            ViewBag.isCourses = false;

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.isHome = false;
            ViewBag.isAdd = false;
            ViewBag.isCourses = false;
            ViewBag.CheckoutCompleteMessage = "Спасибо за заказ";

            return View();
        }
    }
}
