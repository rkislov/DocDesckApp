using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocDesckApp.Models
{
    public class LogViewModel
    {
        [Required]
        [Display(Name ="Логин")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Запомнить")]
        public bool RememberMe { get; set; }
    }
}