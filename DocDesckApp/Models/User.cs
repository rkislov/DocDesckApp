using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocDesckApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        //Фамилия Имя Отчество
        [Required]
        [Display(Name= "Фамилия Имя Отчество")]
        [MaxLength(50, ErrorMessage ="Превышена максимальная длинна записи")]
        public string Name { get; set; }
        //Логин
        [Required]
        [Display(Name = "Логин")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длинна записи")]
        public string Login { get; set; }
        //Пароль
        [Required]
        [Display(Name = "Пароль")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длинна записи")]
        public string Password { get; set; }
        //Должность
        [Required]
        [Display(Name = "Должность")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длинна записи")]
        public string Position { get; set; }
        //Группа
        [Display(Name = "Группа")]
        public Guid? GroupId { get; set; }
        public Group Group { get; set; }
        //Статус
        [Required]
        [Display(Name = "Статус")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}