using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        [Required(ErrorMessage ="Пожалуйста, введите свое имя")]
        [DisplayName("Имя")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите свою фамилию")]
        [DisplayName("Фамилия")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите город проживания")]
        [DisplayName("Город")]
        [StringLength(20)]
        public string City { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите страну проживания")]
        [DisplayName("Страна")]
        [StringLength(20)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите ваш телефон")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email адрес некорректно введен")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])")]
        public string Email { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }

    }
}
