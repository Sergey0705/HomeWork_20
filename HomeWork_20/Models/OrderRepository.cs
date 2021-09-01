using HomeWork_20.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ApplicationDbContext applicationDbContext, ShoppingCart shoppingCart)
        {
            _applicationDbContext = applicationDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _applicationDbContext.Orders.Add(order);

            order.OrderTotal = Convert.ToInt32(_shoppingCart.GetShoppingCartTotal());

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    CourseId = shoppingCartItem.Course.Id,
                    Price = shoppingCartItem.Course.Price
                };

                _applicationDbContext.OrderDetails.Add(orderDetail);
            }
          
            _applicationDbContext.SaveChanges();
        }


    }
}
