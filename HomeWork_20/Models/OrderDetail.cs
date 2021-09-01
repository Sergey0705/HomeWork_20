using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int CourseId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public Course Course { get; set; }
        public Order Order { get; set; }
    }
}
