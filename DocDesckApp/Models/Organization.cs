using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocDesckApp.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длинна записи")]
        [Display(Name = "Короткое наименование")]
        public string ShortName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Превышена максимальная длинна записи")]
        [Display(Name = "Полное наименование")]
        public string FullName { get; set; }
        [Required]
        [MaxLength(6, ErrorMessage = "Превышена максимальная длинна записи")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Индекс")]
        public string Index { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Превышена максимальная длинна записи")]
        [Display(Name = "Адресс")]
        public string Adress { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "Превышена максимальная длинна записи")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string Telefons { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "Превышена максимальная длинна записи")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Факс")]
        public string Fax { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длинна записи")]
        [Display(Name = "Электронный адрес")]
        public string Email { get; set; }
        
    }
}