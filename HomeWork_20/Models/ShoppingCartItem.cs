using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Course Course { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
