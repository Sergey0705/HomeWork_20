using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Пожалуйста, введите свой логин")]
        [MaxLength(20)]
        [DisplayName("Логин")]
        public string LoginProp { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
