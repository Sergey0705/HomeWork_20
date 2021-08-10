using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string CourseName { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
        [DisplayName("URL картинки")]
        public string Image { get; set; }
    }
}
